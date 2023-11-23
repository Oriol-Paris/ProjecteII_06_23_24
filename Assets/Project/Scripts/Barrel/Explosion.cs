using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [field: SerializeField]
    public float damage { get; private set; } = 100f;



    protected void OnTriggerEnter2D(Collider2D collision)
    {
        //OnCollision(collision);
        Debug.Log("Overlap with explosion detected");
        collision.transform.GetComponent<Character>()?.LoseHP(damage);

        Debug.Log(collision.gameObject.tag);
    }

}
