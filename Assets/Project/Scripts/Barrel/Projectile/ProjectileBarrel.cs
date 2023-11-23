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
    protected override void OnCollision(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (explosive)
            Instantiate(explosion, transform.position, transform.rotation);
        else
            collision.transform.GetComponent<Character>()?.LoseHP(damage);

        Destroy(this.gameObject);
    }

    public void ChangeDamage(float amount)
    {
        damage = amount;
    }
}
    
