using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICombatButtonManager : MonoBehaviour
{
    public string buttonPressed;

    [SerializeField]
    public Button attackButton, defenseButton, skillButton, bagButton, fleeButton;

    private void Start()
    {
        attackButton.onClick.AddListener(() => buttonPressed = "attack");
        defenseButton.onClick.AddListener(() => buttonPressed = "defense");
        skillButton.onClick.AddListener(() => buttonPressed = "skill");
        bagButton.onClick.AddListener(() => buttonPressed = "bag");
        fleeButton.onClick.AddListener(() => buttonPressed = "flee");
    }

}
