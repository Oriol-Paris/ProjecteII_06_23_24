using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Projectile
{
    [SerializeField]
    private float speed;

    public override void BulletMovement()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

}
