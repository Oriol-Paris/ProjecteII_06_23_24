using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Character player;
    [SerializeField]
    Slider slider;

    private void Start()
    {
        slider.maxValue = 200f;
        slider.value = player.GetHP();
    }

    private void Update()
    {
        slider.value = player.GetHP();
    }
}
