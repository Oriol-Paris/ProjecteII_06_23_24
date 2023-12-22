using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemy : Character
{

    private bool target = false;
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
        target = true;
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
                }
                else if(ally.Has2ndTarget() && ally.Targeted1st() && !ally.Targeted2nd() /*&& ally.Enemy1Targeted != ally.PossibleEnemyTargeted()*/)
                {
                    Debug.Log("Target 2 selected");
                    ally.Set2ndTarget(this);
                }  
                else if (ally.Has3rdTarget() && ally.Targeted1st() && ally.Targeted2nd() && !ally.Targeted3rd()/*&& ally.Enemy1Targeted != ally.PossibleEnemyTargeted()*/)
                {
                    Debug.Log("Target 3 selected");
                    ally.Set3rdTarget(this);
                }
            }
        }
    }

    public override void OnTurnStart()
    {
    }

    public override void OnTurnEnd()
    {
        activeTurn = false;
        allies[0].sr.color = Color.white;
        allies[1].sr.color = Color.white;
        target = true;
    }
    public override IEnumerator AttackMove()
    {
        newYPosition = new Vector3(0, 0.0005f, 0);
        newXPosition = new Vector3(-0.0025f, 0, 0);
        IEnumerator AttackMove = base.AttackMove();
        while (AttackMove.MoveNext())
        {
            yield return AttackMove.Current;
        }

        attackAnimation = true;
    }
    public override void OnTurnUpdate()
    {
        Ally a = SetTarget();
        a.sr.color = new Color(255, 0, 0, 1);
        if (target)
        {
            Debug.Log("Target selected");
            a.sr.color = new Color(255, 0, 0, 1);
            StartCoroutine(AttackMove());
            target = false;
        }
        if (attackAnimation)
        {
            PhysiqueDamage(SetTarget(), defaultAttackPower);
            Debug.Log("End Turn");
            OnTurnEnd();
            attackAnimation = false;
        }
        
    }

    public override void ForceFinishTurn()
    {
        
    }

    public override bool IsFinished()
    {
        return !activeTurn;
    }
}
