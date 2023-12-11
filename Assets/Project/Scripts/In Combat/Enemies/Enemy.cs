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
            return allies[1];
        return allies[0];
    }

    public void SetAsTarget()
    {
        foreach(Ally ally in allies)
        {
            if (!ally.IsFinished())
            {
                ally.SetTarget(this);
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
