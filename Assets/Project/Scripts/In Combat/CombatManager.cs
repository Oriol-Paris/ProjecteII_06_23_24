using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField]
    private List<Character> characters;

    private void Start()
    {
        OrderCharacters();
    }

    private void OrderCharacters()
    {
        characters = characters.OrderBy(character => character.agility).ToList();
    }

    private void Update()
    {
        Debug.Log("Turn Change");
        characters[0].TurnChanger();

        while (characters[0].activeTurn)
        {
            characters[0].TurnAction();
        }

        for (int i = 1; i < characters.Count(); ++i)
        {
            characters[i].agility -= characters[0].agility;
        }

        OrderCharacters();
    }
}
