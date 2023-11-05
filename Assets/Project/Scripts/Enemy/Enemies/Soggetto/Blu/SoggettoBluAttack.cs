using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoggettoBluAttack : EnemyAttack
{
    [SerializeField]
    private Rigidbody2D bullet;
    [SerializeField]
    private float timeDuration = 2f * 1f;
    private float timer;

    private void Start()
    {
        timer = timeDuration;
    }

    public override void AttackAction()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Flash();
        }
    }

    private void Flash()
    {
        if (timer <=0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timer = timeDuration;
        }

    }

   
}
