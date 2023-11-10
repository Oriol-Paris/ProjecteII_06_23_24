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
    [SerializeField]
    public Rigidbody2D explosion;
    [SerializeField]
    private float cooldown = 1f;
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
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy");
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
    public override void OnCollision(Collision2D collision)
    {
        Character hm = collision.transform.GetComponent<Character>();
        //HealthManagement hm = collision.transform.GetComponent<HealthManagement>();
        if (hm != null)
        {
            hm.LoseHP(damage);
        }
        Destroy(this.gameObject, 10);
    }

    private void Update()
    {
        if (explosion != null)
        {
            cooldown -= Time.deltaTime;
        }

        if (cooldown <= 0)
            Destroy(explosion);
    }
}
    
