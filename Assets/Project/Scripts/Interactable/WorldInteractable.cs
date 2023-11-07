using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteractable : Interactable, HealthManagement
{
    protected float m_maxHealth;
    protected float m_currentHealth;

    public WorldInteractable(int maxHealth)
    {
        m_maxHealth = maxHealth;
        m_currentHealth = m_maxHealth;
    }

    public float MaxHealth
    {
        get { return m_maxHealth; }
    }

    public float CurrentHealth
    {
        get { return m_currentHealth; }
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void LoseHP(float amountLosed)
    {
        m_currentHealth -= amountLosed;
        if (m_currentHealth < 0)
        {
            m_currentHealth = 0;
        }
    }

    public void WinHP(float amountWon)
    {
        m_currentHealth += amountWon;
        if (m_currentHealth > 0)
        {
            m_currentHealth = m_maxHealth;
        }
    }
}
