using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public Item Item;
    public Text ItemName;
    public Sprite ItemIcon;

    private void Start()
    {
        ItemName.text = Item.itemName;
        ItemIcon = Item.icon;

    }



}
