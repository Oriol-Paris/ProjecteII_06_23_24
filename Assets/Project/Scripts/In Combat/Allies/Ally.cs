using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Ally : Character
{
    public Enemy en = null;
    private Enemy en1 = null;
    private Enemy en2 = null;
    private Enemy en3 = null;
    private bool enemy1Targeted = false;
    private bool enemy2Targeted = false;
    private bool enemy3Targeted = false;
    private bool secondTarget = false;
    private bool thirdTarget = false;
    public bool usingSkill = false;

    private int defaultAttackPower = 10;

    [field: SerializeField]
    protected Skill skill;
    [field: SerializeField]
    protected SkillMenu skillMenu;

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
        en1.sr.color = new Color(0, 255, 255, 1);
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
        skillMenu.changeSkillMenu();
        sr.color = new Color(0, 255, 255, 1);
    }

    public override void OnTurnEnd()
    {
        attackAnimation = false;
        Debug.Log("FinishTurn");
        activeTurn = false;
        usingSkill = false;
        sr.color = Color.white;
    }
    public override IEnumerator AttackMove()
    {
        IEnumerator AttackMove = base.AttackMove();
        while (AttackMove.MoveNext())
        {
            yield return AttackMove.Current;
        }
        
        attackAnimation = true;
        //if(attackPressed)
        //PhysiqueDamage(en1, defaultAttackPower);
        //if (skillPressed)
        //{
        //    if (multiSkill2)
        //        MultiTarget2(skill.atkPow);
        //    if (multiSkill3)
        //        MultiTarget3(skill.atkPow);
        //}
        //attackPressed = false;
        //skillPressed = false;
        //enemy1Targeted = false;
        //enemy2Targeted = false;
        //enemy3Targeted = false;
        //OnTurnEnd();

    }
    public override void OnTurnUpdate()
    {
        en.sr.color = new Color(255, 0, 0, 1);
        if (en1 != null)
        en1.sr.color = new Color(255, 0, 0, 1);
        if (attackPressed)
        {
            

            if (enemy1Targeted)
            {
                //StartCoroutine(AttackMove());
                    //if (attackAnimation)
                    //{
                        PhysiqueDamage(en1, defaultAttackPower);
                        enemy1Targeted = false;
                        attackAnimation = false;
                        OnTurnEnd();
                    //}
            }
            //else
                attackPressed = false;
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
            skill.isAlly = true;
            usingSkill = true;
            en = null;
            en1 = null;
            en2 = null;
            en3 = null;
            secondTarget = false;
            thirdTarget = false;
            enemy1Targeted = false;
            enemy2Targeted = false;
            enemy3Targeted = false;
            skillPressed = false;
            Debug.Log("Skill Called");
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
    public void MultiTarget2(int atkPow)
    {
        skill.isAlly = true;
        //if(enemy1Targeted && enemy2Targeted)
        //{
            MagicDamageMultitarget2(en1, en2, atkPow);
        //}
        //enemy1Targeted = false;
        //enemy2Targeted = false;
        //enemy3Targeted = false;
}
    public void MultiTarget3(int atkPow)
    {
        skill.isAlly = true;
        //if (enemy1Targeted && enemy2Targeted && enemy3Targeted)
        //{
            MagicDamageMultitarget3(en1, en2, en3, atkPow);
        //}
        //enemy1Targeted = false;
        //enemy2Targeted = false;
        //enemy3Targeted = false;
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
        secondTarget = !secondTarget;
        thirdTarget = !thirdTarget;
    }
    public bool AttackAnimation()
    {
        return attackAnimation;
    }
    public void SetAttackAnimationFalse()
    {
        attackAnimation = false;
    }
}
