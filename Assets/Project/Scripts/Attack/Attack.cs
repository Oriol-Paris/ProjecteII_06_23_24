using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    protected virtual void Update()
    {
        AttackAction();
    }
    protected virtual void FixedUpdate()
    {

    }
    public abstract void AttackAction();
}
