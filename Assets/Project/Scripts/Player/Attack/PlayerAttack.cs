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
    //private Transform playerTransform;

    //public PlayerAttack(Rigidbody2D bullet, Transform playerTransform)
    //{
    //    this.bullet = bullet;
    //    this.playerTransform = playerTransform;
    //}
    public override void AttackAction()
    {
        if (Input.GetMouseButtonDown(0) || Gamepad.current.rightTrigger.IsActuated())
        {
            if (!player.godMode)
            {
                if (timer > 0)
                    timer -= Time.deltaTime;
                else
                {
                    Instantiate(bullet, transform.position, transform.rotation);
                    timer = timeDuration;
                }
            }

            else
                Instantiate(bullet, transform.position, transform.rotation);

        }
    }
}
