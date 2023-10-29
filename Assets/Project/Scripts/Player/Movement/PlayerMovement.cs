using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    float _movementScale = 50.0f;
    float _xMovement;
    float _yMovement;

    public PlayerMovement(Rigidbody2D rb, float xMovement, float yMovement, float movementScale) : base(rb, xMovement, yMovement, movementScale)
    {
        _rb = rb;
        _xMovement = xMovement;
        _yMovement = yMovement;
        _movementScale = movementScale;
    }

    public override void GetMovementAxis()
    {
        _xMovement = Input.GetAxis("Horizontal");
        _yMovement = Input.GetAxis("Vertical");
    }

    public override void Move()
    {
        GetM_rb().AddForce(Vector2.right * GetM_xMovement() * GetM_movementScale(), ForceMode2D.Force);
        GetM_rb().AddForce(Vector2.up * GetM_yMovement() * GetM_movementScale(), ForceMode2D.Force);
    }
}
