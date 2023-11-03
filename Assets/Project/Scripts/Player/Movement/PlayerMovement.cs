using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    public override void GetMovementAxis()
    {
        m_xMovement = Input.GetAxis("Horizontal");
        m_yMovement = Input.GetAxis("Vertical");
    }

    public override void Move()
    {
        m_rb.AddForce(Vector2.right * m_xMovement * m_movementScale, ForceMode2D.Force);
        m_rb.AddForce(Vector2.up * m_yMovement * m_movementScale, ForceMode2D.Force);
    }

    public Vector2 GetPlayerPos()
    {
        Vector2 playerPos;

        playerPos.x = m_xMovement;
        playerPos.y = m_yMovement;

        return playerPos;
    }
}
