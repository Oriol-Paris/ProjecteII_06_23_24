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
        //ResourcesUsed();
        base.Use();
        if(isAlly)
        {
            if (casterAllyTop.usingSkill)
            {
                if (casterAllyTop.AttackAnimation())
                {
                    casterAllyTop.MultiTarget2(atkPow);
                    casterAllyTop.OnTurnEnd();
                    casterAllyTop.SetAttackAnimationFalse();
                }
            }
            if (casterAllyBottom.usingSkill)
            {
                if (casterAllyTop.AttackAnimation())
                {
                    casterAllyBottom.MultiTarget2(atkPow);
                    casterAllyBottom.OnTurnEnd();
                    casterAllyBottom.SetAttackAnimationFalse();
                }
            }
            
        }
    }
}
