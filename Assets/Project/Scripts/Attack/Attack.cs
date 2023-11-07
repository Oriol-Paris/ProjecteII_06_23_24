using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour 
{
    
    protected virtual void Update()
    {
        AttackAction();
    }

    public abstract void AttackAction();
}
