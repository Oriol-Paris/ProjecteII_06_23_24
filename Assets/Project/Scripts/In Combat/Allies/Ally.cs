using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Ally : Character
{
    public bool isTargeted = false;
    private Enemy en = null;
    private bool enemyTargeted = false;
    public SpriteRenderer sr;
    public override async void TurnAction()
    {
        sr.color = new Color(0, 255, 255, 1);
        //await Task.Equals(en, !null); //No funciona esto
        Damage(en, 1f);
        sr.color = Color.white;
        activeTurn = false;
        
    }

    public void SetTarget(Enemy enemy)
    {
        en = enemy;
        enemyTargeted = true;
    }
}
