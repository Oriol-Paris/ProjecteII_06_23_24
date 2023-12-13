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
    protected Character caster;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    protected virtual void Use()
    {

    }
    protected void ResourcesUsed()
    {
        caster.SetHealth(caster.GetHealth() - lifeRecoil);
        caster.SetMana(caster.GetMana() - manaNeeded);
    }

}
