using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Projectile
{
    protected override void OnCollision(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        collision.transform.GetComponent<Character>()?.LoseHP(damage);
        Destroy(this.gameObject);
    }
}
