using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    protected float m_maxHealth;
    [SerializeField]
    protected float m_currentHealth;
    [SerializeField]
    protected GameObject m_object;

    public bool isDead = false;
 
    protected Movement m_movement;
    protected Attack m_attack;

    public Character(float maxHealth, Movement movement, Attack attack)
    {
        m_maxHealth = maxHealth;
        m_currentHealth = m_maxHealth;
        m_movement = movement;
        m_attack = attack;
    }

    public virtual void Die()
    {
        Debug.Log("Explode0");
        if (m_object.tag != "Barrel"/* || m_object.tag == null*/)
            Destroy(this.gameObject);

        isDead = true;

    }

    public void LoseHP(float amountLosed)
    {
        m_currentHealth -= amountLosed;
        if (m_currentHealth <= 0)
        {
            Die();
            Debug.Log("Explode1");
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

    public void ChangeMaxHP(float amount)
    {
        m_maxHealth = amount;
        m_currentHealth = m_maxHealth;
    }

    public float GetHP()
    {
        return m_currentHealth;
    }

    public float GetMaxHP()
    {
        return m_maxHealth;
    }

   

}


