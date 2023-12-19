using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [field:SerializeField]
    public float manaNeeded { get; private set; }
    [field: SerializeField]
    public int atkPow{ get; private set; }

    [field: SerializeField]
    public int lifeRecoil { get; private set; }

    [field: SerializeField]
    public bool isAlly;

    [field: SerializeField]
    protected Character caster;

    [field: SerializeField]
    protected Ally casterAllyTop;
    [field: SerializeField]
    protected Ally casterAllyBottom;

    [field: SerializeField]
    protected Enemy casterEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public virtual void Use()
    {
        if (isAlly)
        {
            if (casterAllyTop.usingSkill)
            {
                casterAllyTop.AttackMove();
            }
            if (casterAllyBottom.usingSkill)
            {
                casterAllyBottom.AttackMove();
            }
        }
    }
    protected void ResourcesUsed()
    {
        if (isAlly)
        {
            if (casterAllyTop.usingSkill)
            {
                casterAllyTop.SetHealth(casterAllyTop.GetHealth() - lifeRecoil);
                casterAllyTop.SetMana(casterAllyTop.GetMana() - manaNeeded);
            }
            if (casterAllyBottom.usingSkill)
            {
                casterAllyBottom.SetHealth(casterAllyBottom.GetHealth() - lifeRecoil);
                casterAllyBottom.SetMana(casterAllyBottom.GetMana() - manaNeeded);
            }
        }
    }

}
