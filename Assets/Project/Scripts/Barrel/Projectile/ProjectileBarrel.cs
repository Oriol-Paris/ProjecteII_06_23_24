using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBarrel : Projectile
{
    [SerializeField]
    public GameObject enemy;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected Rigidbody2D rb;
    public override void BulletMovement()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        Destroy(this.gameObject, 20);
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Wall");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy");
            Destroy(this.gameObject);
        }
    }
}
    
