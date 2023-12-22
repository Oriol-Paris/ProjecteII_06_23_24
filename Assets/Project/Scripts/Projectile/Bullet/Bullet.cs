using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : Projectile
{
    [SerializeField]
    protected float speed;
    protected override void FixedUpdate()
    {
        BulletMovement();
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Wall");
            Destroy(this.gameObject);
        }
    }

    public abstract void BulletMovement();
}
