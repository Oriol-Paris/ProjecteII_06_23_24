using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    protected float damage = 10;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision(collision);
        Character hm = collision.transform.GetComponent<Character>();
        if (hm != null)
        {
            hm.LoseHP(damage);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Wall");
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy");
        }
        if (collision.gameObject.tag == "Barrel")
        {
            Debug.Log("Barrel");
        }
    }
    public virtual void OnCollision(Collision2D collision)
    {
        Character hm = collision.transform.GetComponent<Character>();
        //HealthManagement hm = collision.transform.GetComponent<HealthManagement>();
        if (hm != null)
        {
            hm.LoseHP(damage);
        }
    }
    public void ChangeDamage(float amount)
    {
        damage = amount;
    }
}
