using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HealthManagement
{
    void LoseHP(float amountLosed);

    void WinHP(float amountWon);

    void Die();
    
}
