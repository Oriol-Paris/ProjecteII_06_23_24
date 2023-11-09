using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Projectile
{
    [SerializeField]
    public GameObject enemy;
    [SerializeField]
    protected float speed;

    public override void BulletMovement()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        Destroy(this.gameObject, 5);
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
            Destroy(enemy);
        }
    }
}
