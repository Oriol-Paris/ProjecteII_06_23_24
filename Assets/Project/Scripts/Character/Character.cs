using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : HealthManagement
{
    protected int m_maxHealth;
    protected int m_currentHealth;
    protected Movement m_movement;
    protected Attack m_attack;

    public Character(int maxHealth, Movement movement, Attack attack)
    {
        m_maxHealth = maxHealth;
        m_currentHealth = m_maxHealth;
        m_movement = movement;
        m_attack = attack;
    }

    public int MaxHealth
    {
        get { return m_maxHealth; }
    }

    public int CurrentHealth
    {
        get { return m_currentHealth; }
    }

    public void LoseHP(int amountLosed)
    {
        m_currentHealth -= amountLosed;
        if (m_currentHealth < 0)
        {
            m_currentHealth = 0;
        }
    }

    public void WinHP(int amountWon) 
    {
        m_currentHealth += amountWon;
        if(m_currentHealth > 0)
        {
            m_currentHealth = m_maxHealth;
        }
    }


}


