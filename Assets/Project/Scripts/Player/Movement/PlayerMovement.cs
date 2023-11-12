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
    private Vector2 cDir;
    bool controller;
    public override void GetMovementAxis()
    {
        //if (dash)
        //{
        //    return;
        //}
        movementDir = Vector2.right * Input.GetAxis("Horizontal") + Vector2.up * Input.GetAxis("Vertical");
        Vector2 move = Vector2.right * (m_rb.velocity.normalized) +  (movementDir.normalized);

        cDir = Vector2.right * Input.GetAxis("Mouse X") + Vector2.down * Input.GetAxis("Mouse Y");

        //Vector3  mousePosition = Mouse.current.position.ReadValue();
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        if(!controller)
        transform.right = direction;
        else
        transform.right = cDir;
        if (Input.GetKey(KeyCode.C))
        {
            controller = !controller;
        }
        if (Input.GetKeyDown(KeyCode.G) || Gamepad.current.leftShoulder.IsActuated())
        {
            godMode = !godMode;
        }
        if (Input.GetMouseButtonDown(1)/* || Gamepad.current.buttonEast.IsActuated()*/)
        {
            //m_rb.velocity = movementDir * dashSpeed*4;
            //cooldownTimer = cooldown;
            //dashTimer = dashTime;
            //dash = true;
            Debug.Log("DASH");
        }
    }

    public override void Move()
    {
        //if (dash)
        //{
        //    return;
        //}
        if (movementDir.sqrMagnitude < 0.001f)
            return;

        bool alignedMovement = Vector2.Dot(m_rb.velocity.normalized, movementDir.normalized) > 0.0f;

        Vector2 adjustedMovement = (movementDir.sqrMagnitude > 1f ? movementDir.normalized : movementDir) * m_movementScale * Time.fixedDeltaTime;
        if (!alignedMovement)
            adjustedMovement *= 2f;


        //if(cooldownTimer < 0)
        m_rb.AddForce(adjustedMovement, ForceMode2D.Force);

        //if (dash == true)
        //{
        //    m_rb.velocity = movementDir * dashSpeed;
        //}
        //if (dashTimer > 0f)
        //{
        //    dashTimer -= Time.deltaTime;
        //    if (dashTimer <= 0f)
        //    {
        //        dash = false;
        //    }
        //}
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
        //if (cooldownTimer <= 0)
        //{

        //}
        //else (cooldownTimer > 0)
        //{
        //    cooldownTimer -= Time.deltaTime;
        //}
    }

    //public void Dash()
    //{
    //    if ((Input.GetMouseButtonDown(1) || Gamepad.current.buttonEast.IsActuated()))
    //    {
    //        m_rb.velocity = movementDir * dashSpeed;
    //        //cooldownTimer = cooldown;
    //        print("DASH");
    //    }

        
    //}

    void Start()
    {
        godMode = false;
    }

    protected override void Update()
    {
        GetMovementAxis();
    }
    protected override void FixedUpdate() //Con Dash() el FixedUpdate() se queda ahi y no avanza más, en algún momento del Dash() se queda encallado
    {
        Move();

        //Dash();
        
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

    public void ChangeSpeed(float amount)
    {
        m_movementScale = amount;
    }
}
