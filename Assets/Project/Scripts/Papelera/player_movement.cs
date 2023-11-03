using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float movementScale = 100.0f;
    [SerializeField]
    public bool godMode;
    public int Health { get; private set; }//Public get, private set (todos pueden usarla pero no cambiarla)
    Vector2 movementDir;
    
    private void Start()
    {
        //var pM = new PlayerMovement(rb, xMovement, yMovement, movementScale);
    }

    // Update is called once per frame
    void Update()
    {
        movementDir = Vector2.right * Input.GetAxis("Horizontal") + Vector2.up * Input.GetAxis("Vertical");

        if (Gamepad.current.leftShoulder.IsPressed() || Input.GetButtonDown("p"))
        {
            godMode = !godMode;
        }

    }
    void FixedUpdate()
    {
        if (movementDir.sqrMagnitude < 0.001f)
            return;

        bool alignedMovement = Vector2.Dot(rb.velocity.normalized, movementDir.normalized) > 0.0f;

        Vector2 adjustedMovement = (movementDir.sqrMagnitude > 1f ? movementDir.normalized : movementDir) * movementScale * Time.fixedDeltaTime;
        if (!alignedMovement)
            adjustedMovement *= 2f;


        rb.AddForce(adjustedMovement, ForceMode2D.Force);
    }
}
