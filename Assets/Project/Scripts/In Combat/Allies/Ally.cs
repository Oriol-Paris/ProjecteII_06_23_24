using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Character
{
    public bool isTargeted = false;
    private Enemy en = null;
    private bool enemyTargeted = false;
    public SpriteRenderer sr;
    public override void TurnAction()
    {
        sr.color = new Color(0, 255, 255, 1);
        while (!enemyTargeted) {}
        Damage(en, 1f);
        sr.color = Color.white;
    }

    public void SetTarget(Enemy enemy)
    {
        en = enemy;
        enemyTargeted = true;
    }
}
