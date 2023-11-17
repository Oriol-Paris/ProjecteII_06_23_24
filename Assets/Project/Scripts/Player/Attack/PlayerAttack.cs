using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : Attack
{
    [SerializeField]
    protected Rigidbody2D bullet;
    [SerializeField]
    protected Rigidbody2D bigBullet;
    [SerializeField]
    protected Rigidbody2D grabBarrel;
    [SerializeField]
    protected Rigidbody2D barrel;
    [SerializeField]
    protected PlayerMovement player;
    [SerializeField]
    private GrabbedBarrel gBarrel;
    private float timeDuration = 0.4f;
    private float timer = 0.0f;
    private bool shoot = true;
    private int numShots = 1;
    [SerializeField]
    public bool bulletBig = false;

    [SerializeField]
    protected Camera cam;

    public override void AttackAction()
    {
        timer -= Time.deltaTime;
        shoot = timer < 0f;

        if (Input.GetMouseButton(0))
        {
            if (gBarrel.grabbed is true)
            {
                //Barrel code
                Instantiate(barrel, transform.position, grabBarrel.transform.rotation);
                timer = timeDuration;
            }
            else
            {
                Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                if (!player.godMode)
                {
                    if (shoot)
                    {
                        timer -= Time.deltaTime;
                        Instantiate(bulletBig ? bigBullet : bullet, player.m_rb.position, Quaternion.Euler(0f, 0f, player.m_rb.rotation));
                        shoot = false;
                        timer = timeDuration;
                    }
                }
                else
                {
                    Instantiate(bulletBig ? bigBullet : bullet, player.m_rb.position, Quaternion.Euler(0f, 0f, player.m_rb.rotation));
                }
            }
            gBarrel.grabbed = false;
        }
    }

    public void DoubleShot()
    {
        numShots = 2;
    }

    public void TripleShot()
    {
        numShots = 3;
    }

    public void BigBullet()
    {
        bulletBig = true;
    }

}
