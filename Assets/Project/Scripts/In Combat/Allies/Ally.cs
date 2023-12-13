using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Ally : Character
{
    private Enemy en = null;
    private bool enemyTargeted = false;

    private int defaultAttackPower = 10;

    [field: SerializeField]
    public Inventory alliesInventory { get; protected set; }


    [SerializeField]
    public Button attackButton, defenseButton, skillButton, bagButton, fleeButton;

    private bool attackPressed, defensePressed, skillPressed, bagPressed, fleePressed;

    private void Start()
    {
        attackButton.onClick.AddListener(() => attackPressed = true);
        defenseButton.onClick.AddListener(() => defensePressed = true);
        skillButton.onClick.AddListener(() => skillPressed = true);
        bagButton.onClick.AddListener(() => bagPressed = true);
        fleeButton.onClick.AddListener(() => fleePressed = true);

        
    }

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
        
        if(attackPressed)
        {
            attackPressed = false;
            Debug.Log("Attack Called");
            if(enemyTargeted)
            {
                PhysiqueDamage(en, defaultAttackPower);
                enemyTargeted = false;
                OnTurnEnd();
            }
        }
        if(defensePressed)
        {
            defensePressed = false;
            Debug.Log("Defense Called");
            DefenseUp(50);
            OnTurnEnd();
        }
        if(skillPressed)
        {
            skillPressed = false;
        }
        if(bagPressed)
        {
            bagPressed = false;

        }
        if(fleePressed)
        {
            fleePressed = false;
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
