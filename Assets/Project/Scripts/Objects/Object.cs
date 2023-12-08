using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

enum Class
{
    HPRECOVERY,
    MANARECOVERY,
    STRINCREASER,
    INTINCREASER,
    RESINCREASER,
    LUCKINCREASER,
    INMORTAL,
    REVIVE
}

public class Object : MonoBehaviour
{

    [field: SerializeField]
    public int powerAmount { get; protected set; }

    [SerializeField]
    internal List<Class> classes = new List<Class>();

    protected void Use(Character target)
    {
        foreach(Class effect in classes)
        {
            switch(effect)
            {
                case Class.HPRECOVERY:
                    target.SetHealth(target.GetHealth() + powerAmount);
                    break;
                case Class.MANARECOVERY:
                    target.SetMana(target.GetMana() + powerAmount);
                    break; 
                case Class.STRINCREASER: 
                    target.strength = target.strength + powerAmount;
                    break;
                case Class.INTINCREASER:
                    target.intelligence = target.intelligence + powerAmount;
                    break;
                case Class.RESINCREASER:
                    target.resistance = target.resistance + powerAmount;
                    break;
                case Class.LUCKINCREASER:
                    target.luck = target.luck + powerAmount;
                    break;
                case Class.INMORTAL: 
                    break;
                case Class.REVIVE:
                    break;

            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
