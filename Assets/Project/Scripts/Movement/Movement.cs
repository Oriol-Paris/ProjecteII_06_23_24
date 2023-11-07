using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D m_rb;
    protected Vector2 movementDir;
    [SerializeField]
    protected float m_movementScale;
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
