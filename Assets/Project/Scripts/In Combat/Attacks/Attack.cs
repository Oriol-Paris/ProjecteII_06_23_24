using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AtkRange { NONE, ONE, TWO, THREE, ALL, SELF }

public class Attack : MonoBehaviour
{
    [SerializeField]
    AtkRange range;
    [SerializeField]
    float attackMultiplier;

    public Attack(float atkmult, AtkRange rng)
    {
        attackMultiplier = atkmult;
        range = rng;
    }

    public AtkRange GetRange()
    {
        return range;
    }

    public float GetAtkMult()
    { 
        return attackMultiplier; 
    }

}
