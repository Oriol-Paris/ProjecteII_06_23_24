using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D m_rb;
    protected float m_xMovement;
    protected float m_yMovement;
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
