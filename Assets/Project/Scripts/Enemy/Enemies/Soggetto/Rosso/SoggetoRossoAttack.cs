using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoggettoRossoAttack : EnemyAttack
{

    private Rigidbody2D bullet;
    private Transform soggetoTransform;
    private Vector2 destination;

    [SerializeField]
    private Rigidbody2D player;
    [SerializeField]

    private float timer = 0.0f;
    private float interval = 3.0f;

    public SoggettoRossoAttack(Rigidbody2D bullet, Transform soggetoTransform, Rigidbody2D player)
    {
        this.bullet = bullet;
        this.soggetoTransform = soggetoTransform;
        this.player = player;
        destination = player.position;
    }


    public override void AttackAction()
    {
        Rigidbody2D bulletInstance = Object.Instantiate(bullet, soggetoTransform.position, soggetoTransform.rotation);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            AttackAction();
            timer = 0.0f;
        }
    }
}
