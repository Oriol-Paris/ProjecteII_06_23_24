using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
    [SerializeField]
    private List<Ally> allies;
    [SerializeField]
    private List<Enemy> enemies;
    [SerializeField]
    private List<Character> characters = new List<Character>();


    protected void Awake()
    {
        foreach (Ally ally in allies)
        {
            characters.Add(ally);
        }

        foreach (Enemy enemy in enemies)
        {
            characters.Add(enemy);
        }

        Debug.Log("Turn Change");
        characters[0].TurnChanger();
        characters[0].OnTurnStart();
    }

    private void Update()
    {
        if (!characters[0].IsFinished())
        {
            characters[0].OnTurnUpdate();
        }
        else
        {
            RemoveDeadCharacters();

            if (CheckGameOver())
                EndCombat();

            characters[0].OnTurnEnd();

            OrderCharacters();

            Debug.Log("Turn Change");
            characters[0].TurnChanger();
            characters[0].OnTurnStart();
        }
    }


    private bool CheckGameOver()
    {
        if (allies.Count == 0 || enemies.Count == 0)
        {
            return true;
        }
        else
            return false;
    }


    private void EndCombat()
    {
        SceneManager.LoadScene("demo");
    }


    private void RemoveDeadCharacters()
    {
        for (int i = characters.Count - 1; i > 0; --i)
        {
            if (characters[i] == null)
            {
                characters.RemoveAt(i);
            }
        }

        for (int i = allies.Count - 1; i > 0; --i)
        {
            if (allies[i] == null)
            {
                allies.RemoveAt(i);
            }
        }

        for (int i = enemies.Count - 1; i > 0; --i)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }
        }
    }

    private void OrderCharacters()
    {
        Character c = characters[0];
        characters.RemoveAt(0);
        characters.Add(c);
    }
}
