using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : Projectile
{
    public override void OnCollisionEnter2D()
    {
        Destroy(this.gameObject, 10);
    }
    public abstract void BulletMovement();
}
