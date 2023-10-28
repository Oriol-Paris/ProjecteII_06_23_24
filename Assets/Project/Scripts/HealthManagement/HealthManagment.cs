using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HealthManagement
{
    int MaxHealth { get; }
    int CurrentHealth { get; }

    void LoseHP(int amountLosed);

    void WinHP(int amountWon);
    
}
