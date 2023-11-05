using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoggettoMovement : EnemyMovement
{
    [SerializeField]
    private Rigidbody2D objective;

    private Vector2 dirSign;
    private Vector2 destination;
    public override void GetMovementAxis()
    {
        destination = objective.transform.position;
        dirSign.x = destination.x - transform.position.x;
        dirSign.y = destination.y - transform.position.y;
        movementDir = Vector2.right *Mathf.Sign(dirSign.x) + Vector2.up*Mathf.Sign(dirSign.y);
    }

    public override void Move()
    {
        if (movementDir.sqrMagnitude < 0.001f)
            return;

        bool alignedMovement = Vector2.Dot(m_rb.velocity.normalized, movementDir.normalized) > 0.0f;

        Vector2 adjustedMovement = (movementDir.sqrMagnitude > 1f ? movementDir.normalized : movementDir) * m_movementScale * Time.fixedDeltaTime;
        if (!alignedMovement)
            adjustedMovement *= 2f;

        m_rb.AddForce(adjustedMovement, ForceMode2D.Force);
    }
}
