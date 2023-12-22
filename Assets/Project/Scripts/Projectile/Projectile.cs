using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected virtual void Update()
    {
        
    }
    protected virtual void FixedUpdate()
    {
        
    }
    public abstract void OnCollisionEnter2D(Collision2D collision);
}
