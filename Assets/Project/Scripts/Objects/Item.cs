using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;


[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public enum ItemType { POTION, ETHER, ATK_BUFF };

    public ItemType itemType;
    public string itemName;
    public int power;
    public Sprite icon;
    public UiItem uiObject;

    public void Use(Character target)
    {

        if (target == null)
        {
            Debug.Log("There's no target selected");
            return;
        }

        switch (itemType)
        {
            case Item.ItemType.POTION:
                target.SetHealth(target.GetHealth() + power);
                break;
            case Item.ItemType.ETHER:
                target.SetMana(target.GetMana() + power);
                break;
            case Item.ItemType.ATK_BUFF:

                break;
        }
    }
}
