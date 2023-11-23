using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Movement
{
    [SerializeField]
    public bool godMode = false;
    [SerializeField]
    private bool dash = false;
    [SerializeField]
    private float dashSpeed = 50f;
    [SerializeField]
    private float cooldown = 1f;
    private float cooldownTimer;
    [SerializeField]
    private float dashTime = 0.5f;
    private float dashTimer;

    protected Vector2 playerToMouse;

    public override void GetMovementAxis()
    {
        movementDir = Vector2.right * Input.GetAxis("Horizontal") + Vector2.up * Input.GetAxis("Vertical");
        playerToMouse = m_rb.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.G))
            godMode = !godMode;
    }
    public override void Move()
    {
        UpdateMovement();
        UpdateRotation();
    }

    private void UpdateMovement()
    {
        if (movementDir.sqrMagnitude < 0.001f)
            return;

        bool alignedMovement = Vector2.Dot(m_rb.velocity.normalized, movementDir.normalized) > 0.0f;

        Vector2 adjustedMovement = (movementDir.sqrMagnitude > 1f ? movementDir.normalized : movementDir) * m_movementScale * Time.fixedDeltaTime;
        if (!alignedMovement)
            adjustedMovement *= 2f;

        m_rb.AddForce(adjustedMovement, ForceMode2D.Force);
    }
    private void UpdateRotation()
    {
        m_rb.SetRotation(Vector2.SignedAngle(Vector2.right, playerToMouse) + 180f);
    }
}
