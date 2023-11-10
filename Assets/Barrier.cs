using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField]
    List<Character> enemies;

    void Update()
    {
        foreach (Character enemy in enemies)
        {
            if (enemy.isDead is false) 
            {
                return;
            }
        }

        this.gameObject.SetActive(false);
    }
}
