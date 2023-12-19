using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mugetsu : Skill
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Use()
    {
        ResourcesUsed();
        if(isAlly)
        {
            if (casterAllyTop.usingSkill)
            {
                casterAllyTop.multiSkill2 = true;
                //casterAllyTop.MultiTarget2(atkPow);
                //casterAllyTop.OnTurnEnd();
            }
            if (casterAllyBottom.usingSkill)
            {
                casterAllyBottom.multiSkill2 = true;
                //casterAllyBottom.MultiTarget2(atkPow);
                //casterAllyBottom.OnTurnEnd();
            }
            
        }
        base.Use();
    }
}
