using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    public override void GetMovementAxis()
    {
    }

    public override void Move()
    {
    }

    protected override void FixedUpdate()
    {
        Move();  
    }

    protected override void Update()
    {
        GetMovementAxis();
    }
}
