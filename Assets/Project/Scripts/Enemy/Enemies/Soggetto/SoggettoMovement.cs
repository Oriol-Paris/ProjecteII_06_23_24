using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoggettoMovement : Movement
{
    [SerializeField]
    private Rigidbody2D objective;
    public override void GetMovementAxis()
    {
        movementDir = (objective.transform.position - transform.position).normalized;
    }

    public override void Move()
    {
        Vector2 adjustedMovement = movementDir * m_movementScale;

        m_rb.AddForce(adjustedMovement, ForceMode2D.Force);
        
    }
}
