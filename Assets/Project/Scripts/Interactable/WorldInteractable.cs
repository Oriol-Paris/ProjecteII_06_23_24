using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteractable : MonoBehaviour, Interactable, HealthManagement
{
    protected int m_maxHealth;
    protected int m_currentHealth;

    protected virtual void Update()
    {

    }
    protected virtual void FixedUpdate()
    {
        Interact();
    }
    public virtual void Interact()
    {

    }
    public WorldInteractable(int maxHealth)
    {
        m_maxHealth = maxHealth;
        m_currentHealth = m_maxHealth;
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
        if (m_currentHealth > 0)
        {
            m_currentHealth = m_maxHealth;
        }
    }
}
