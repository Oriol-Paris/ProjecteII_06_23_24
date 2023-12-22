using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    [SerializeField]
    public GameObject enemy;
    public override void BulletMovement()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        Destroy(this.gameObject, 5);
    }
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy");
            Destroy(enemy);
        }
    }
}
