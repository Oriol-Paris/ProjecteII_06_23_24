using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoggettoMovement : Movement
{
    [SerializeField]
    protected Rigidbody2D objective;

    [SerializeField]
    protected float force = 50.0f;

    protected Vector2 destination;
    public override void GetMovementAxis()
    {
        movementDir = (objective.transform.position - transform.position).normalized;
    }

    public override void Move()
    {
        Vector2 adjustedMovement = movementDir * m_movementScale;

        m_rb.AddForce(adjustedMovement, ForceMode2D.Force);
        
    }

    protected override void FixedUpdate()
    {
        Move();
    }

    protected override void Update()
    {
        GetMovementAxis();
    }
}
