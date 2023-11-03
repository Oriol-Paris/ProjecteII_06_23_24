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
    public SoggettoBluMovement(Rigidbody2D rb, float xMovement, float yMovement, float movementScale)
        :base(rb, xMovement, yMovement, movementScale)
    {
        m_rb = rb;
        m_xMovement = xMovement;
        m_yMovement = yMovement;
        m_movementScale = movementScale;
    }

  

    protected void FixedUpdate()
    {
        if (destination != null)
        {
            destination = objective.position;

            m_xMovement = destination.x - m_rb.position.x;
            m_yMovement = destination.y - m_rb.position.y;
            

            m_rb.AddForce(Vector2.right * m_xMovement * m_movementScale, ForceMode2D.Impulse);
            m_rb.AddForce(Vector2.up * m_yMovement * m_movementScale, ForceMode2D.Impulse);

        }
    }
}
