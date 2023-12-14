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
    private bool defenseCalled = false;

    [SerializeField]
    protected int accuracy;
    protected bool activeTurn;

    public SpriteRenderer sr;

    private float magicalDefense;
    private float physicalDefense;

    

    public bool skillUsed = false;

    //protected void RecoverHp(float hp){health += hp;}
    //protected void RecoverMana(float m){mana += mana;}
    //protected void IncreaseResistance(int resistanceUp){resistance += resistanceUp;}
    //protected void IncreaseStrenght(int strengthUp){strength += strengthUp;}
    //protected void IncreaseIntelligence(int intelligenceUp){intelligence += intelligenceUp;}
    //public void IncreaseVitality(int vitalityUp){vitality += vitalityUp;}
    //public void IncreaseLuck(int luckUp){luck += luckUp;}
    //public void DecreasResistance(int resistanceDown){resistance -= resistanceDown;}
    //public void DecreaseStrenght(int strengthDown){strength -= strengthDown;}
    //public void DecreaseIntelligence(int intelligenceDown){intelligence -= intelligenceDown;}
    //public void DecreaseVitality(int vitalityDown){vitality -= vitalityDown;}
    //public void DecreaseLuck(int luckDown){luck -= luckDown;}
    //public void InmortalityActivated(){isInmortal = true;}
    //public void InmortalityDesactivated(){isInmortal = false;}

    protected bool GetIsInmortal() { return isInmortal;}


    //remember that increase is a percentage->%, it will reduce directly the atkVal by the percentage
    protected void DefenseUp()
    {
        defenseCalled = true;
    }

    public void ManaDown(int decrease)
    {
        mana -= decrease;
    }

    private void Awake()
    {
        maxHealth = 5.0f * vitality;
        health = maxHealth;
        maxMana = 1.5f * intelligence;
        mana = maxMana;
        physicalDefense = resistance * 0.7f + strength * 0.3f;
        magicalDefense = resistance * 0.7f + intelligence * 0.3f;
    }   

    protected virtual void PhysiqueDamage(Character other, int atkPow)
    {
        if (Random.Range(1, 100) < accuracy)
        {
            float myDefense = other.physicalDefense;

            if (defenseCalled)
                other.physicalDefense = physicalDefense * 2.0f;

            float atkVal = 0.01f *Random.Range(85,100) * (((0.2f * level + 1) * strength * atkPow)/ (25.0f* other.physicalDefense) + 2) ;
            if (Random.Range(1, 100) < luck * 1.25)
                atkVal = atkVal * 1.5f;
            other.health -= atkVal;
            string atkMessage = "Attack Connected! -> " + atkVal.ToString() + " damage";

            Debug.Log(atkMessage);

            if(defenseCalled)
            {
                defenseCalled = false;
                other.physicalDefense = myDefense;
            }

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
    protected virtual void MagicDamage(Character other, int atkPow)
    {
        if (Random.Range(1, 100) < accuracy)
        {

            float myDefense = other.magicalDefense;

            if(defenseCalled)
                other.magicalDefense = magicalDefense * 2.0f;
            
            
            float atkVal = 0.01f * Random.Range(85, 100) * (((0.2f * level + 1) * intelligence * atkPow) / (25.0f * other.magicalDefense) + 2);
            if (Random.Range(1, 100) < luck * 1.25)
                atkVal = atkVal * 1.5f;
            other.health -= atkVal;
            string atkMessage = "Attack Connected! -> " + atkVal.ToString() + " damage";
            Debug.Log(atkMessage);

            if(defenseCalled)
            {
                defenseCalled = false;
                other.magicalDefense = myDefense;
            }

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
        if (other.health < 0)
        {
            Destroy(other.gameObject);
        }
    }

    protected virtual void MagicDamageMultitarget2(Character other1, Character other2, int atkPow)
    {
        if (Random.Range(1, 100) < accuracy)
        {
            float enemy1Defense = other1.resistance * 0.7f + other1.intelligence * 0.3f;
            float enemy2Defense = other2.resistance * 0.7f + other2.intelligence * 0.3f;
            float atk1Val = 0.01f * Random.Range(85, 100) * (((0.2f * level + 1) * intelligence * atkPow) / (25.0f * enemy1Defense) + 2);
            float atk2Val = 0.01f * Random.Range(85, 100) * (((0.2f * level + 1) * intelligence * atkPow) / (25.0f * enemy2Defense) + 2);
            if (Random.Range(1, 100) < luck * 1.25)
            {
                atk1Val = atk1Val * 1.5f;
                atk2Val = atk2Val * 1.5f;
            }

            other1.health -= atk1Val;
            other2.health -= atk2Val;
            string atkMessage = "Attacks Connected! -> " + atk1Val.ToString() + " damage and " + atk2Val.ToString() + "damage.";
            Debug.Log(atkMessage);
        }
        else
        {
            Debug.Log("Attacks Missed!");
        }
        if (other1.health < 0)
        {
            Destroy(other1.gameObject);
        }
        if (other2.health < 0)
        {
            Destroy(other2.gameObject);
        }
    }

    protected virtual void MagicDamageMultitarget3(Character other1, Character other2, Character other3, int atkPow)
    {
        if (Random.Range(1, 100) < accuracy)
        {
            float enemy1Defense = other1.resistance * 0.7f + other1.intelligence * 0.3f;
            float enemy2Defense = other2.resistance * 0.7f + other2.intelligence * 0.3f;
            float enemy3Defense = other3.resistance * 0.7f + other3.intelligence * 0.3f;
            float atk1Val = 0.01f * Random.Range(85, 100) * (((0.2f * level + 1) * intelligence * atkPow) / (25.0f * enemy1Defense) + 2);
            float atk2Val = 0.01f * Random.Range(85, 100) * (((0.2f * level + 1) * intelligence * atkPow) / (25.0f * enemy2Defense) + 2);
            float atk3Val = 0.01f * Random.Range(85, 100) * (((0.2f * level + 1) * intelligence * atkPow) / (25.0f * enemy3Defense) + 2);
            if (Random.Range(1, 100) < luck * 1.25)
            {
                atk1Val = atk1Val * 1.5f;
                atk2Val = atk2Val * 1.5f;
                atk3Val = atk3Val * 1.5f;
            }
                
            other1.health -= atk1Val;
            other2.health -= atk2Val;
            other3.health -= atk3Val;
            string atkMessage = "Attacks Connected! -> " + atk1Val.ToString() + " damage, " + atk2Val.ToString() + " damage and " + atk3Val.ToString() + "damage.";
            Debug.Log(atkMessage);
        }
        else
        {
            Debug.Log("Attacks Missed!");
        }
        if (other1.health < 0)
        {
            Destroy(other1.gameObject);
        }
        if (other2.health < 0)
        {
            Destroy(other2.gameObject);
        }
        if (other3.health < 0)
        {
            Destroy(other3.gameObject);
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

    public float GetMaxMana() { return maxMana; }

    public void SetMana(float newMana) {  mana = newMana; }

}
