using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Attack
{

    private Rigidbody2D bullet;
    private Transform playerTransform;

    public PlayerAttack(Rigidbody2D bullet, Transform playerTransform)
    {
        this.bullet = bullet;
        this.playerTransform = playerTransform;
    }
    public override void AttackAction()
    {
        Rigidbody2D bulletInstance = Object.Instantiate(bullet, playerTransform.position, playerTransform.rotation);
    }
}
