using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBarrel : Projectile
{
    [SerializeField]
    protected Rigidbody2D rb;
    public override void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
    
