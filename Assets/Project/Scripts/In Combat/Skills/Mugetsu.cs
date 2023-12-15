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
                atkPow = (int)casterAllyTop.en1.GetHealth()/2 + (int)casterAllyTop.en2.GetHealth()/2;
                casterAllyTop.MultiTarget2(atkPow);
                casterAllyTop.OnTurnEnd();
            }
            if (casterAllyBottom.usingSkill)
            {
                casterAllyBottom.MultiTarget2(atkPow);
                casterAllyBottom.OnTurnEnd();
            }
            
        }
    }
}
