using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [field: SerializeField]
    public int level { get; protected set; }
    [field: SerializeField]
    public int vitality { get; protected set; }
    [field: SerializeField]
    public int strength { get; protected set; }
    [field: SerializeField]
    public int resistance { get; protected set; }
    [field: SerializeField]
    public int intelligence { get; protected set; }
    //[field: SerializeField]
    //public int agility { get; protected set; }
    [field: SerializeField]
    public int luck { get; protected set; }
    private float health;
    private float maxHealth;
    [SerializeField]
    protected int accuracy;
    protected bool activeTurn;

    public SpriteRenderer sr;

    private void Awake()
    {
        maxHealth = 5.0f * vitality;
        health = maxHealth;
    }

   

    protected virtual void PhysiqueDamage(Character other, int atkPow)
    {
        if (Random.Range(1, 100) < accuracy)
        {
            float enemyDefense = other.resistance * 0.7f + other.strength * 0.3f;
            //falta el atkPower, como no existen diferentes ataques de momento lo dejare como si la potencia fuera 1
            float atkVal = 0.01f *Random.Range(85,100) * (((0.2f * level + 1) * strength * atkPow)/ (25.0f* enemyDefense) + 2) ;
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
            //falta el atkPower, como no existen diferentes ataques de momento lo dejare como si la potencia fuera 1
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
    public float GetMaxHealth() { return maxHealth; }
}
