using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbedBarrel : GrabbedObject
{
    Vector2 movementDir;
    [SerializeField]
    float m_movementScale;
    protected override void Grab()
    {
        
        //Instantiate(m_rb, transform.position, transform.rotation);
    }
    protected override void Track()
    {
        
        //movementDir = Vector2.right * Input.GetAxis("Horizontal") + Vector2.up * Input.GetAxis("Vertical");
        ////m_rb.position = player.position + Vector2.up;
    }
    protected override void Move()
    {
        //transform.position = player.transform.position;
        //if (movementDir.sqrMagnitude < 0.001f)
        //    return;

        //bool alignedMovement = Vector2.Dot(m_rb.velocity.normalized, movementDir.normalized) > 0.0f;

        //Vector2 adjustedMovement = (movementDir.sqrMagnitude > 1f ? movementDir.normalized : movementDir) * m_movementScale * Time.fixedDeltaTime;
        //if (!alignedMovement)
        //    adjustedMovement *= 2f;


        //m_rb.AddForce(adjustedMovement, ForceMode2D.Force);
    }
}
