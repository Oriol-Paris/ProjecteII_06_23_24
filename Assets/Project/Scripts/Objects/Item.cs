using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public enum ItemType { POTION, ATK_BUFF };

    public ItemType itemType;
    public string itemName;
    public int power;
    public Sprite icon;
    public UiItem uiObject;
}
