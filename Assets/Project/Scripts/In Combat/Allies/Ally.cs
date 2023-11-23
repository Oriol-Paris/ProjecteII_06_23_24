using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Character
{
    public bool isTargeted = false;
    private Enemy en = null;
    private bool enemyTargeted = false;
    public override void TurnAction()
    {
        while (!enemyTargeted) {}
        Damage(en, 1f);
    }

    public void SetTarget(Enemy enemy)
    {
        en = enemy;
        enemyTargeted = true;
    }
}
