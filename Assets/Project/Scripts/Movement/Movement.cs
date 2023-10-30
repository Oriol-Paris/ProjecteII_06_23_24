using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    protected Rigidbody2D m_rb;
    protected float m_xMovement;
    protected float m_yMovement;
    protected float m_movementScale;
    protected Movement (Rigidbody2D rb, float xMovement, float yMovement, float movementScale)
    {
        m_rb = rb;
        m_xMovement = xMovement;
        m_yMovement = yMovement;
        m_movementScale = movementScale;
    }

    //public Rigidbody2D GetM_rb()
    //{
    //    return m_rb;
    //}
    //public float GetM_xMovement()
    //{
    //    return m_xMovement;
    //}
    //public float GetM_yMovement()
    //{
    //    return m_yMovement;
    //}
    //public float GetM_movementScale()
    //{
    //    return m_movementScale;
    //}

    public abstract void GetMovementAxis();
    

    public abstract void Move();
    
}
