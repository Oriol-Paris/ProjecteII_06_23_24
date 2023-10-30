using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoggettoMovement : EnemyMovement
{
    public SoggettoMovement(Rigidbody2D rb, float xMovement, float yMovement, float movementScale) : base(rb, xMovement, yMovement, movementScale)
    {
        m_rb = rb;
        m_xMovement = xMovement;
        m_yMovement = yMovement;
        m_movementScale = movementScale;
    }
}
