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
        throw new System.NotImplementedException();
    }

    public override void OnTurnEnd()
    {
        activeTurn = false;
    }

    public override void OnTurnUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void ForceFinishTurn()
    {
        throw new System.NotImplementedException();
    }

    public override bool IsFinished()
    {
        return !activeTurn;
    }
}
