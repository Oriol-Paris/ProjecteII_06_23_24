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
        Character hm = collision.transform.GetComponent<Character>();
        if (hm != null)
        {
            hm.LoseHP(damage);
        }
        Destroy(this.gameObject, 10);
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
        if (collision.gameObject.tag == "Barrel")
        {
            Debug.Log("Barrel");
            Destroy(this.gameObject);
        }
    }
    public void ChangeDamage(float amount)
    {
        damage = amount;
    }
}
