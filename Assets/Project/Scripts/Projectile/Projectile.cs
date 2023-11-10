using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected float damage = 10;
    public abstract void BulletMovement();
    protected virtual void FixedUpdate()
    {
        BulletMovement();
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision(collision);
    }
    public virtual void OnCollision(Collision2D collision)
    {
        Character hm = collision.transform.GetComponent<Character>();
        //HealthManagement hm = collision.transform.GetComponent<HealthManagement>();
        if (hm != null)
        {
            hm.LoseHP(damage);
        }
        Destroy(this.gameObject, 10);
    }
}
