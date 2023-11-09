using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Movement
{
    [SerializeField]
    public bool godMode;
    [SerializeField]
    private bool dash;
    [SerializeField]
    private float dashSpeed = 50f;
    [SerializeField]
    private float cooldown = 1f;
    private float cooldownTimer;
    [SerializeField]
    private float dashTime = 0.5f;
    private float dashTimer;
    public override void GetMovementAxis()
    {
        if (dash)
        {
            return;
        }
        movementDir = Vector2.right * Input.GetAxis("Horizontal") + Vector2.up * Input.GetAxis("Vertical");
        Vector2 move = Vector2.right * (m_rb.velocity.normalized) +  (movementDir.normalized);

        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.right = direction;

        if (Input.GetKey(KeyCode.G) || Gamepad.current.leftShoulder.IsActuated())
        {
            godMode = !godMode;
        }

        if (Input.GetMouseButton(1) || Gamepad.current.bButton.IsActuated())
        {
            dash = true;
            StartCoroutine(Dash());
        }



    }

    public override void Move()
    {
        if (dash)
        {
            return;
        }
        //Vector3  mousePosition = Mouse.current.position.ReadValue();
        


        if (movementDir.sqrMagnitude < 0.001f)
            return;

        bool alignedMovement = Vector2.Dot(m_rb.velocity.normalized, movementDir.normalized) > 0.0f;

        Vector2 adjustedMovement = (movementDir.sqrMagnitude > 1f ? movementDir.normalized : movementDir) * m_movementScale * Time.fixedDeltaTime;
        if (!alignedMovement)
            adjustedMovement *= 2f;


        //if(cooldownTimer < 0)
        m_rb.AddForce(adjustedMovement, ForceMode2D.Force);

        //if (Input.GetMouseButton(1) || Gamepad.current.bButton.IsActuated())
        //{
        //    if (cooldownTimer <= 0)
        //    {
        //        dashTimer = dashTime;
        //    }
        //}
        //if (dashTimer >= 0)
        //{
        //    m_rb.velocity = movementDir * dashSpeed;
        //    dashTimer -= Time.deltaTime;
        //}
        //if (dashTimer <= 0)
        //{
        //    cooldownTimer = cooldown;
        //}
        //if (cooldownTimer > 0)
        //{
        //    cooldownTimer -= Time.deltaTime;
        //}
        //if (Input.GetMouseButton(1) || Gamepad.current.bButton.IsActuated())
        //{
        //    m_rb.velocity = movementDir * m_movementScale/250;
        //}
    }
    IEnumerator Dash()
    {
        dash = true;
        m_rb.velocity = movementDir * dashSpeed;
        yield return new WaitForSeconds(dashTime);
        dash = false;
    }
    protected override void Update()
    {
        GetMovementAxis();
        Dash();
    }
    protected override void FixedUpdate()
    {
        Move();
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
    //public Vector2 GetPlayerPos()
    //{
    //    Vector2 playerPos;

    //    playerPos.x = m_xMovement;
    //    playerPos.y = m_yMovement;

    //    return playerPos;
    //}
}
