using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : Attack
{
    [SerializeField]
    protected Rigidbody2D bullet;
    [SerializeField]
    protected PlayerMovement player;
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
            if (!player.godMode)
            {
                if (shoot)
                {
                    timer -= Time.deltaTime;
                    Instantiate(bullet, transform.position, player.transform.rotation);
                    shoot = false;
                }
            }
            else
                Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
