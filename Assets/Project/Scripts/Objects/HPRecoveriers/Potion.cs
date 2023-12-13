using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Object
{
    // Start is called before the first frame update

   
    void Start()
    {
        name = "potion";
        powerAmount = 15;
        classes.Add(Class.HPRECOVERY);
    } 
}
