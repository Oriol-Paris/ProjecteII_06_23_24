using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoggettoBluMovement : SoggettoMovement
{
    [SerializeField]
    private Rigidbody2D objective;
    [SerializeField]
    public float force = 50.0f;
    
    private Vector2 destination;

    protected override void FixedUpdate()
    {
        if (destination != null)
        {
            destination = objective.position;

            movementDir.x = destination.x - m_rb.position.x;
            movementDir.y = destination.y - m_rb.position.y;

            m_rb.AddForce(Vector2.right * movementDir.x * m_movementScale, ForceMode2D.Impulse);
            m_rb.AddForce(Vector2.up * movementDir.y * m_movementScale, ForceMode2D.Impulse);
        }
    }
}
