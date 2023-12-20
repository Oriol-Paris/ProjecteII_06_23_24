using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemy : Character
{
    [SerializeField]
    private List<Ally> allies;

    int defaultAttackPower = 10;

    public Ally SetTarget()
    {
        allies = allies.OrderBy(ally => ally.GetHealth()).ToList();
        if (!(allies[0].GetHealth() > 0))
        {
            allies[1].sr.color = new Color(255, 0, 0, 1);
            return allies[1];
        }
        allies[0].sr.color = new Color(255, 0, 0, 1);
        return allies[0];
    }

    //public void SetAsTarget()
    //{
    //    foreach(Ally ally in allies)
    //    {
    //        if (!ally.IsFinished())
    //        {
    //            ally.SetTarget(this);
    //        }
    //    }
    //}
    public void SetAsTarget()
    {
        
        foreach (Ally ally in allies)
        {
            
            if (!ally.IsFinished())
            {
                //ally.SetPossibleTarget(this);
                if (!ally.Targeted1st())
                {
                    Debug.Log("Target 1 selected");
                    ally.SetTarget(this);
                    sr.color = new Color(255, 0, 0, 1);
                }
                else if(ally.Has2ndTarget() && ally.Targeted1st() && !ally.Targeted2nd() /*&& ally.Enemy1Targeted != ally.PossibleEnemyTargeted()*/)
                {
                    Debug.Log("Target 2 selected");
                    ally.Set2ndTarget(this);
                    sr.color = new Color(255, 0, 0, 1);
                }  
                else if (ally.Has3rdTarget() && ally.Targeted1st() && ally.Targeted2nd() && !ally.Targeted3rd()/*&& ally.Enemy1Targeted != ally.PossibleEnemyTargeted()*/)
                {
                    Debug.Log("Target 3 selected");
                    ally.Set3rdTarget(this);
                    sr.color = new Color(255, 0, 0, 1);
                }
            }
        }
    }

    public override void OnTurnStart()
    {
        sr.color = new Color(255, 0, 0, 1);
    }

    public override void OnTurnEnd()
    {
        activeTurn = false;
    }

    public override void OnTurnUpdate()
    {
        Ally a = SetTarget();
        if (a != null)
        {
            PhysiqueDamage(SetTarget(), defaultAttackPower);
        }
        Debug.Log("End Turn");
        OnTurnEnd();
    }

    public override void ForceFinishTurn()
    {
        
    }

    public override bool IsFinished()
    {
        return !activeTurn;
    }
}
