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
    public GameObject explosion;
    [SerializeField]
    private float cooldown = 0.25f;
    [SerializeField]
    GrabbedBarrel grabbedBarrel;
    [SerializeField]
    public ColorChanger colorChanger;
    private bool hasExploded = false;
    public bool explosive;
    public override void BulletMovement()
    {
        if (explosive)
        {
            colorChanger.ChangeColor(Color.red);
        }
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        Destroy(this.gameObject, 20);
        
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        Character hm = collision.transform.GetComponent<Character>();
        if (hm != null)
        {
            hm.LoseHP(damage);
        }

        if (explosive)
        {
            if (!hasExploded)
            {
                StartCoroutine(Explosion());
                hasExploded = true;
            }
            Destroy(this.gameObject, 10);
            rb.transform.position = new Vector2(1000f, 1000f);
        }
        else
        {
            if (collision.gameObject.tag == "Wall")
            {
                Debug.Log("Wall");
                Destroy(this.gameObject, 10);
                rb.transform.position = new Vector2(1000f, 1000f);
            }
            if (collision.gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy");
            }
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
    public void ChangeDamage(float amount)
    {
        damage = amount;
    }

    IEnumerator Explosion()
    {
        GameObject explosionInstance = Instantiate(explosion, transform.position, transform.rotation);
        yield return new WaitForSeconds(cooldown);
        Destroy(explosionInstance);
    }
}
    
