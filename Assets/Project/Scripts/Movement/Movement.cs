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
    protected abstract void Update();
    protected abstract void FixedUpdate();
    public abstract void GetMovementAxis();
    

    public abstract void Move();
    
}
