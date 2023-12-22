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
        base.Use();
        if(isAlly)
        {
            if (casterAllyTop.usingSkill)
            {
                casterAllyTop.MultiTarget2(atkPow);
                casterAllyTop.OnTurnEnd();
                if (casterAllyTop.AttackAnimation())
                {
                    
                    casterAllyTop.SetAttackAnimationFalse();
                }
            }
            if (casterAllyBottom.usingSkill)
            {
                casterAllyBottom.MultiTarget2(atkPow);
                casterAllyBottom.OnTurnEnd();
                if (casterAllyTop.AttackAnimation())
                {
                    
                    casterAllyBottom.SetAttackAnimationFalse();
                }
            }
            
        }
    }
}
