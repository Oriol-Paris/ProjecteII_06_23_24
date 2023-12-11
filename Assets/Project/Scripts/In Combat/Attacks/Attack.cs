using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AtkRange { NONE, ONE, TWO, THREE, ALL, SELF }

public class Attack : MonoBehaviour
{
    [SerializeField]
    AtkRange range;
    [SerializeField]
    float attackPower;

    public Attack(float atkPow, AtkRange rng)
    {
        attackPower = atkPow;
        range = rng;
    }

    public AtkRange GetRange()
    {
        return range;
    }

    public float GetAtkMult()
    { 
        return attackPower; 
    }

}
