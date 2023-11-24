using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemy : Character
{
    [SerializeField]
    private List<Ally> allies;

    public Ally SetTarget()
    {
        allies = allies.OrderByDescending(ally => ally.health).ToList();
        allies[0].isTargeted = true;
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
        
    }

    public override void OnTurnEnd()
    {
        activeTurn = false;
    }

    public override void OnTurnUpdate()
    {
        if (activeTurn)
        {
            Damage(SetTarget(), 1f);
            OnTurnEnd();
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
