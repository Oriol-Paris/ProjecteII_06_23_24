using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [field: SerializeField]
    public int level { get; set; }
    [field: SerializeField]
    public int vitality { get; set; }
    [field: SerializeField]
    public int strength { get; set; }
    [field: SerializeField]
    public int resistance { get; set; }
    [field: SerializeField]
    public int intelligence { get; set; }
    //[field: SerializeField]
    //public int agility { get; protected set; }
    [field: SerializeField]
    public int luck { get; set; }
    private float health;
    private float maxHealth;
    private float mana;
    private float maxMana;

    protected bool isInmortal = false;

    [SerializeField]
    protected int accuracy;
    protected bool activeTurn;

    public SpriteRenderer sr;

    private float defenseIncrease = 1.0f;

    protected bool GetIsInmortal() { return isInmortal;}


    //remember that increase is a percentage->%, it will reduce directly the atkVal by the percentage
    protected void DefenseUp(int increase)
    {
        defenseIncrease = increase;
    }

    private void Awake()
    {
        maxHealth = 5.0f * vitality;
        health = maxHealth;
        maxMana = 1.5f * intelligence;
        mana = maxMana;
    }   

    protected virtual void PhysiqueDamage(Character other, int atkPow)
    {
        if (Random.Range(1, 100) < accuracy)
        {
            float enemyDefense = other.resistance * 0.7f + other.strength * 0.3f;
            float atkVal = 0.01f *Random.Range(85,100) * (((0.2f * level + 1) * strength * atkPow)/ (25.0f* enemyDefense) + 2) ;
            if (Random.Range(1, 100) < luck * 1.25)
                atkVal = atkVal * 1.5f;

            if(defenseIncrease != 100)
            {
                atkVal = (defenseIncrease * atkVal / 100);
                defenseIncrease = 100;
            }
            other.health -= atkVal;
            string atkMessage = "Attack Connected! -> " + atkVal.ToString() + " damage";

            Debug.Log(atkMessage);

            if (other.GetIsInmortal())
            {
                if (other.health <= 0)
                    other.health = 1;
                Debug.Log("Enemy is Inmortal");
            }
        }
        else
        {
            Debug.Log("Attack Missed!");
        }
        if (other.health < 0 )
        {
            Destroy(other.gameObject);
        }
    }
    protected virtual void MagicDamage(Character other)
    {
        if (Random.Range(1, 100) < accuracy)
        {
            float enemyDefense = other.resistance * 0.7f + other.intelligence * 0.3f;
            float atkVal = 0.01f * Random.Range(85, 100) * (((0.2f * level + 1) * intelligence) / (25.0f * enemyDefense) + 2);
            if (Random.Range(1, 100) < luck * 1.25)
                atkVal = atkVal * 1.5f;
            other.health -= atkVal;
            string atkMessage = "Attack Connected! -> " + atkVal.ToString() + " damage";
            Debug.Log(atkMessage);
        }
        else
        {
            Debug.Log("Attack Missed!");
        }
        if (other.health < 0)
        {
            Destroy(other.gameObject);
        }
    }
       
    public void TurnChanger()   
    {  
        activeTurn = !activeTurn;
    }
    public abstract void OnTurnStart();
    public abstract void OnTurnEnd();
    public abstract void OnTurnUpdate();
    public abstract void ForceFinishTurn();
    public abstract bool IsFinished();

    public float GetHealth() { return health; }

    public void SetHealth(float newHealth) { health = newHealth; }
    public float GetMaxHealth() { return maxHealth; }

    public float GetMana() {  return mana; }

    public void SetMana(float newMana) {  mana = newMana; }

}
