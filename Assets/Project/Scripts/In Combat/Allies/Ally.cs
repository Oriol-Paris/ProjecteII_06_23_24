using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Ally : Character
{
    private Enemy en = null;
    private bool enemyTargeted = false;

    public void SetTarget(Enemy enemy)
    {
        en = enemy;
        enemyTargeted = true;
    }

    public override void OnTurnStart()
    {
        sr.color = new Color(0, 255, 255, 1);
    }

    public override void OnTurnEnd()
    {
        sr.color = Color.white;
        activeTurn = false;
    }

    public override void OnTurnUpdate()
    {
        if (enemyTargeted)
        {
            Damage(en, 1f);
            enemyTargeted = false;
            OnTurnEnd();
        }
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
