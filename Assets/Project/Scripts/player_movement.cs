using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float movementScale = 50.0f;
    [SerializeField]
    public int Health { get; private set; }//Public get, private set (todos pueden usarla pero no cambiarla)
    private float xMovement = 0.0f;
    private float yMovement = 0.0f;
    
    private void Start()
    {
        var pM = new PlayerMovement(rb, xMovement, yMovement, movementScale);
    }

    // Update is called once per frame
    void Update()
    {
        xMovement = Input.GetAxis("Horizontal");
        yMovement = Input.GetAxis("Vertical");
        //if (Input.GetKey("w"))
        //{
        //    yMovement = Input.GetAxis("Vertical");
        //    xMovement = Input.GetAxis("Horizontal");
        //}
        //if (Input.GetKey("s"))
        //{
        //    yMovement = Input.GetAxis("Vertical");
        //    xMovement = Input.GetAxis("Horizontal");
        //}
        //if (Input.GetKey("w") && Input.GetKey("s"))
        //{

        //}
        //if (Input.GetKey("a"))
        //{
        //    xMovement = Input.GetAxis("Horizontal");
        //    yMovement = Input.GetAxis("Vertical");
        //}
        //if (Input.GetKey("d"))
        //{
        //    yMovement = Input.GetAxis("Vertical");
        //    xMovement = Input.GetAxis("Horizontal");
        //}
        //if (Input.GetKey("a") && Input.GetKey("d"))
        //{

        //}
    }
    void FixedUpdate()
    {
        rb.AddForce(Vector2.right * xMovement * movementScale, ForceMode2D.Force);
        rb.AddForce(Vector2.up * yMovement * movementScale, ForceMode2D.Force);
        //if (Input.GetKey("w"))
        //{
        //    rb.AddForce(speedY * Time.deltaTime);
        //}
        //if (Input.GetKey("s"))
        //{
        //    rb.AddForce(speedY * Time.deltaTime);
        //}
        //if (Input.GetKey("a"))
        //{
        //    rb.AddForce(speedX * Time.deltaTime);
        //}
        //if (Input.GetKey("d"))
        //{
        //    rb.AddForce(speedX * Time.deltaTime);
        //}

    }
}
