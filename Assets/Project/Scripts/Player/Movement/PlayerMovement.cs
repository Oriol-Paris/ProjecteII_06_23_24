using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Movement
{
    [SerializeField]
    public bool godMode;
    public override void GetMovementAxis()
    {
        movementDir = Vector2.right * Input.GetAxis("Horizontal") + Vector2.up * Input.GetAxis("Vertical");

        if (Gamepad.current.leftShoulder.IsPressed() || Input.GetButtonDown("p"))
        {
            godMode = !godMode;
        }
    }

    public override void Move()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.right = direction;

        if (movementDir.sqrMagnitude < 0.001f)
            return;

        bool alignedMovement = Vector2.Dot(m_rb.velocity.normalized, movementDir.normalized) > 0.0f;

        Vector2 adjustedMovement = (movementDir.sqrMagnitude > 1f ? movementDir.normalized : movementDir) * m_movementScale * Time.fixedDeltaTime;
        if (!alignedMovement)
            adjustedMovement *= 2f;


        m_rb.AddForce(adjustedMovement, ForceMode2D.Force);
    }

    //public Vector2 GetPlayerPos()
    //{
    //    Vector2 playerPos;

    //    playerPos.x = m_xMovement;
    //    playerPos.y = m_yMovement;

    //    return playerPos;
    //}
}
