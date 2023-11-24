using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [field: SerializeField]
    public int health {  get; protected set; }
    [field: SerializeField]
    public int maxHealth { get; protected set; }
    [SerializeField]
    protected int attack;
    [SerializeField]
    public int agility;
    [SerializeField]
    protected int accuracy;
    protected bool activeTurn;

    public SpriteRenderer sr;

    protected virtual void Damage(Character other, float atkMult)
    {
        if (Random.Range(1, 100) < accuracy)
        {
            int atkVal = (int)Mathf.Ceil(atkMult * (float)attack);
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

    public void TurnChanger()
    {
        activeTurn = !activeTurn;
    }
    public abstract void OnTurnStart();
    public abstract void OnTurnEnd();
    public abstract void OnTurnUpdate();
    public abstract void ForceFinishTurn();
    public abstract bool IsFinished();
}
