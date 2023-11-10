using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    Collision2D collision;
    [SerializeField]
    private Rigidbody2D _enemy;
    [SerializeField]
    public GameObject enemy;
    [SerializeField]
    public float damage = 10f;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        Destroy(this.gameObject, 5);
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
        if (collision.gameObject.tag == "Barrel")
        {
            Debug.Log("Barrel");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            Destroy(this.gameObject);
        }

    }

    public void ChangeDamage(float amount)
    {
        damage = amount;
    }
}
