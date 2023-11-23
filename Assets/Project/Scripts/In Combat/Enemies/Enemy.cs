using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Enemy : Character
{
    [SerializeField]
    private List<Ally> allies;
    public override void TurnAction()
    {
        Damage(SetTarget(), 1);
    }

    public Ally SetTarget()
    {
        allies = allies.OrderByDescending(ally => ally.health).ToList();
        allies[0].isTargeted = true;
        return allies[0];
    }

    private void SetAsTarget() //Se llama desde la UI
    {
        foreach(Ally ally in allies)
        {
            if (ally.activeTurn)
            {
                ally.SetTarget(this);
            }
        }
    }
}
