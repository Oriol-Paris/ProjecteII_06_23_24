using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HealthManagement
{
    float MaxHealth { get; }
    float CurrentHealth { get; }

    void LoseHP(float amountLosed);

    void WinHP(float amountWon);

    void Die();
    
}
