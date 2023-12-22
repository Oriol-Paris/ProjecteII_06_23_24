using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiItem : MonoBehaviour
{
    public Image img;
    public TextMeshProUGUI name;
    public TextMeshProUGUI amount;
    
    public void Setup(Sprite s, string name, int amount)
    {
        img.sprite = s;
        this.name.text = name;
        this.amount.text = amount.ToString();
    }

    public void UpdateAmount(int newAmount)
    {
        this.amount.text = newAmount.ToString();
    }

    
}
