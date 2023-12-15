using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int power;
    public Sprite icon;
    public ItemType itemType;


    public enum ItemType
    {
        HealthPotion,
        ManaPotion
    }
}
