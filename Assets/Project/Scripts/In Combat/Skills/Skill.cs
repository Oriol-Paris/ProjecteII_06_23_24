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
        ResourcesUsed();
        //if (isAlly)
        //{
        //    if (casterAllyTop.usingSkill)
        //    {
        //        StartCoroutine(casterAllyTop.AttackMove());
        //    }
        //    if (casterAllyBottom.usingSkill)
        //    {
        //        StartCoroutine(casterAllyBottom.AttackMove());
        //    }
        //}
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

    protected void UnselectTargets()
    {
        if (casterAllyTop.usingSkill)
        {
            if (casterAllyTop.en1 != null)
                casterAllyTop.en1.sr.color = Color.white;
            if (casterAllyTop.en2 != null)
                casterAllyTop.en2.sr.color = Color.white;
            if (casterAllyTop.en3 != null)
                casterAllyTop.en3.sr.color = Color.white;
        }
        if (casterAllyBottom.usingSkill)
        {
            if (casterAllyBottom.en1 != null)
                casterAllyBottom.en1.sr.color = Color.white;
            if (casterAllyBottom.en2 != null)
                casterAllyBottom.en2.sr.color = Color.white;
            if (casterAllyBottom.en3 != null)
                casterAllyBottom.en3.sr.color = Color.white;
        }
    }

}
