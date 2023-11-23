using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D physics;
    [field: SerializeField]
    public float damage { get; protected set; } = 10;
    [field: SerializeField]
    public float lifetime { get; protected set; } = 5.0f;
    [field: SerializeField]
    public float shootForce { get; protected set; } = 1000.0f;
    public virtual void BulletMovement() { }
    protected abstract void OnCollision(Collision2D collision);
    protected virtual void Start()
    {
        physics = this.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, lifetime);
        physics.AddForce(transform.right * shootForce, ForceMode2D.Impulse);
    }
    protected virtual void FixedUpdate()
    {
        BulletMovement();
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision(collision);
    }
}
