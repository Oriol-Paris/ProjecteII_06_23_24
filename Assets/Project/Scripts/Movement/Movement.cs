using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [field: SerializeField]
    public Rigidbody2D m_rb { get; protected set; }
    protected Vector2 movementDir;
    [field: SerializeField]
    public float m_movementScale { get; protected set; } = 1.0f;
    protected virtual void Update()
    {
        GetMovementAxis();
    }
    protected virtual void FixedUpdate()
    {
        Move();
    }
    public abstract void GetMovementAxis();
    public abstract void Move();
    
}
