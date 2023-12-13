using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Character character;

    private void Start()
    {
        slider.maxValue = character.GetMaxMana();
    }
    void Update()
    {
        slider.value = character.GetMana();
    }
}
