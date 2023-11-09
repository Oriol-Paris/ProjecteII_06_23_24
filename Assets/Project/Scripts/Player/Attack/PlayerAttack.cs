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
    protected Rigidbody2D grabBarrel;
    [SerializeField]
    protected Rigidbody2D barrel;
    [SerializeField]
    protected PlayerMovement player;
    [SerializeField]
    private GrabbedBarrel gBarrel;
    private float timeDuration = 0.4f;
    private float timer;
    private bool shoot = true;
    //private Transform playerTransform;

    //public PlayerAttack(Rigidbody2D bullet, Transform playerTransform)
    //{
    //    this.bullet = bullet;
    //    this.playerTransform = playerTransform;
    //}
    public override void AttackAction()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
            timer = timeDuration;
            shoot = true;
        }
        if (Input.GetMouseButton(0) || Gamepad.current.rightTrigger.IsActuated())
        {
            if (gBarrel.grabbed == false)
            {
                if (!player.godMode)
                {
                    if (shoot)
                    {
                        timer -= Time.deltaTime;
                        Instantiate(bullet, transform.position, transform.rotation);
                        shoot = false;
                        timer = timeDuration;
                    }
                }
                else
                    Instantiate(bullet, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(barrel, transform.position, grabBarrel.transform.rotation);
                shoot = false;
                timer = timeDuration;
                //gBarrel.grabbed = false;
            }
            gBarrel.grabbed = false;
        }
    }
}
