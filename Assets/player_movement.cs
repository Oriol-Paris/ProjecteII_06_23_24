using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private Vector2 speedX = new Vector2(50000f, 0f);
    private Vector2 speedY = new Vector2(0f, 50000f);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            speedY.y = 50000f;
            speedY.x = 0f;
        }
        if (Input.GetKey("s"))
        {
            speedY.y = -50000f;
            speedY.x = 0f;
        }
        if (Input.GetKey("w") && Input.GetKey("s"))
        {
            speedY.y = 0f;
            speedY.x = 0f;
        }
        if (Input.GetKey("a"))
        {
            speedX.y = 0f;
            speedX.x = -50000f;
        }
        if (Input.GetKey("d"))
        {
            speedX.y = 0f;
            speedX.x = 50000f;
        }
        if (Input.GetKey("a") && Input.GetKey("d"))
        {
            speedX.y = 0f;
            speedX.x = 0f;
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(speedY * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(speedY * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(speedX * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(speedX * Time.deltaTime);
        }

    }
}
