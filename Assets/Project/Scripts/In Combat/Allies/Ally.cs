using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;



public class Ally : Character
{
    private Enemy en = null;
    private bool enemyTargeted = false;
    [SerializeField]
    private UICombatButtonManager buttonManager;

    private int defaultAttackPower = 15;

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
        switch(buttonManager.buttonPressed)
        {
            case "attack":
                if (enemyTargeted)
                {
                    PhysiqueDamage(en, defaultAttackPower);
                    enemyTargeted = false;
                    OnTurnEnd();
                }
                break;
            case "defense":

                break;
            case "skill":

                break;
            case "bag":
                break;
            case "flee":
                break;

            default: break;

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
