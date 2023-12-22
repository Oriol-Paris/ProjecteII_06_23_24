using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Ally : Character
{
    public Enemy en = null;
    public Enemy en1 = null;
    public Enemy en2 = null;
    public Enemy en3 = null;
    public Ally ally1 = null;
    public Ally ally2 = null;
    public Ally ally3 = null;
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
    public void SetAllyTarget(Ally ally)
    {
        ally1 = ally;
    }
    public void Set2ndAllyTarget(Ally ally)
    {
        ally2 = ally;
    }
    public void Set3rdAllyTarget(Ally ally)
    {
        ally3 = ally;
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

    public void SetAsTarget()
    {

        foreach (Ally ally in allies)
        {

            if (!ally.IsFinished())
            {
                //ally.SetPossibleTarget(this);
                if (ally.ally1 == null)
                {
                    Debug.Log("Ally target 1 selected");
                    ally.SetAllyTarget(this);
                }
                else if (ally.Has2ndTarget() && ally.ally1 != null && ally.ally2 == null /*&& ally.Enemy1Targeted != ally.PossibleEnemyTargeted()*/)
                {
                    Debug.Log("Ally target 2 selected");
                    ally.Set2ndAllyTarget(this);
                }
                else if (ally.Has3rdTarget() && ally.ally1 != null && ally.ally1 != null && ally.ally3 == null/*&& ally.Enemy1Targeted != ally.PossibleEnemyTargeted()*/)
                {
                    Debug.Log("Ally target 3 selected");
                    ally.Set3rdAllyTarget(this);
                }
            }
        }
    }
    public override void OnTurnStart()
    {
        skillMenu.changeSkillMenu();
        sr.color = new Color(0, 255, 255, 1);
        en = null;
        en1 = null;
        en2 = null;
        en3 = null;
    }

    public override void OnTurnEnd()
    {
        sr.color = Color.white;
        attackAnimation = false;
        Debug.Log("FinishTurn");
        activeTurn = false;
        usingSkill = false;
        en = null;
        en1 = null;
        en2 = null;
        en3 = null;
        ally1 = null;
        ally2 = null;
        ally3 = null;
    }
    public override IEnumerator AttackMove()
    {
        //newYPosition =new  Vector3(0, 0.01f, 0);
        //newXPosition =new  Vector3(0.1f, 0, 0);
        IEnumerator AttackMove = base.AttackMove();
        while (AttackMove.MoveNext())
        {
            yield return AttackMove.Current;
        }

        attackAnimation = true;
    }
    public override void OnTurnUpdate()
    {
        if (en1 != null)
            en1.sr.color = new Color(255, 0, 0, 1);
        if (en2 != null)
            en2.sr.color = new Color(255, 0, 0, 1);
        if (en3 != null)
            en3.sr.color = new Color(255, 0, 0, 1);
        if (ally1 != null)
            ally1.sr.color = new Color(255, 0, 0, 1);
        if (ally2 != null)
            ally2.sr.color = new Color(255, 0, 0, 1);
        if (ally3 != null)
            ally3.sr.color = new Color(255, 0, 0, 1);
        if (attackAnimation)
        {
            PhysiqueDamage(en1, defaultAttackPower);
            attackAnimation = false;
            OnTurnEnd();
        }
        if (attackPressed)
        {
            

            if (enemy1Targeted)
            {
                StartCoroutine(AttackMove());
                    //if (attackAnimation)
                    //{
                        
                        enemy1Targeted = false;
                        
                if (en1 != null)
                    en1.sr.color = Color.white;
                if (en2 != null)
                        en2.sr.color = Color.white;
                    if (en3 != null)
                        en3.sr.color = Color.white;
                    
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
