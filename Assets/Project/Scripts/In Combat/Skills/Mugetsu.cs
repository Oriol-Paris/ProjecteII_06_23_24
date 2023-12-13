using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mugetsu : Skill
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void Use()
    {
        ResourcesUsed();
        caster.MagicDamageMultitarget2();
    }
}
