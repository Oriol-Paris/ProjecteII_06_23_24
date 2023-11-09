using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    protected float m_maxHealth;
    [SerializeField]
    protected float m_currentHealth;

 
    protected Movement m_movement;
    protected Attack m_attack;

    public Character(float maxHealth, Movement movement, Attack attack)
    {
        m_maxHealth = maxHealth;
        m_currentHealth = m_maxHealth;
        m_movement = movement;
        m_attack = attack;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public void LoseHP(float amountLosed)
    {
        m_currentHealth -= amountLosed;
        if (m_currentHealth < 0)
        {
            Die();
        }
    }

    public void WinHP(float amountWon) 
    {
        m_currentHealth += amountWon;
        if(m_currentHealth > 0)
        {
            m_currentHealth = m_maxHealth;
        }
    }

   

}


