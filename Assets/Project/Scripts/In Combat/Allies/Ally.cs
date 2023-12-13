using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Ally : Character
{
    private Enemy en = null;
    private Enemy en1 = null;
    private Enemy en2 = null;
    private Enemy en3 = null;
    private bool enemy1Targeted = false;
    private bool enemy2Targeted = false;
    private bool enemy3Targeted = false;
    private bool secondTarget = false;
    private bool thirdTarget = false;

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

    public void SetPossibleTarget(Enemy enemy)
    {
        en = enemy;
    }
    public void SetTarget(Enemy enemy)
    {
        en1 = enemy;
        enemy1Targeted = true;
    }
    public void Set2ndTarget(Enemy enemy2)
    {
        en2 = enemy2;
        enemy2Targeted = true;
    }
    public void Set3rdTarget(Enemy enemy3)
    {
        en3 = enemy3;
        enemy3Targeted = true;
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
            if(enemy1Targeted)
            {
                PhysiqueDamage(en1, defaultAttackPower);
                enemy1Targeted = false;
                OnTurnEnd();
            }
        }
        if(defensePressed)
        {
            defensePressed = false;
            Debug.Log("Defense Called");
            DefenseUp();
            OnTurnEnd();
        }
        if(skillPressed)
        {
            skillPressed = false;
            Debug.Log("Skill Called");
            //if (enemy1Targeted)
            //{
            //    MagicDamage(en1);
            //}
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
    public void MultiTarget2()
    {
        //if(enemy1Targeted && enemy2Targeted)
        //{
            MagicDamageMultitarget2(en1, en2, 5);
        //}
        //enemy1Targeted = false;
        //enemy2Targeted = false;
        //enemy3Targeted = false;
}
    public void MultiTarget3()
    {
        if(enemy1Targeted && enemy2Targeted && enemy3Targeted)
        {
            MagicDamageMultitarget3(en1, en2, en3, 5);
        }
        enemy1Targeted = false;
        enemy2Targeted = false;
        enemy3Targeted = false;
    }
    public bool Has2ndTarget()
    {
        return secondTarget;
    }

    public bool Has3rdTarget()
    {
        return thirdTarget;
    }
    public bool Targeted1st()
    {
        return enemy1Targeted;
    }
    public bool Targeted2nd()
    {
        return enemy2Targeted;
    }
    public bool Targeted3rd()
    {
        return enemy3Targeted;
    }

    public Enemy PossibleEnemyTargeted()
    {
        return en;
    }
    public Enemy Enemy1Targeted()
    {
        return en1;
    }
    public Enemy Enemy2Targeted()
    {
        return en2;
    }
    public Enemy Enemy3Targeted()
    {
        return en3;
    }

    public void changeEnemy1TargetState()
    {
        enemy1Targeted = !enemy1Targeted;
    }
    public void changeEnemy2TargetState()
    {
        enemy2Targeted = !enemy2Targeted;
    }
    public void changeEnemy3TargetState()
    {
        enemy3Targeted = !enemy3Targeted;
    }

    public void changeSecondTargetState()
    {
        secondTarget = !secondTarget;
    }
    public void changeThirdTargetState()
    {
        thirdTarget = !thirdTarget;
    }
}
