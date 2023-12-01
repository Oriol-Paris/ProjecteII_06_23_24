using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Character character;

    private void Start()
    {
        slider.maxValue = character.GetMaxHealth();
    }
    void Update()
    {
        slider.value = character.GetHealth();
    }
}
