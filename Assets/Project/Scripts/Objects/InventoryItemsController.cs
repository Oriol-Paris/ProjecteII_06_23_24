using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemsController : MonoBehaviour
{
    Item item;

    public Button RemoveButton;

    public void RemoveItem()
    {
        InventoryManegement.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }


    public void UseItem()
    {
        switch(item.itemType)
        {
            case Item.ItemType.HealthPotion:

                break;
            case Item.ItemType.ManaPotion: 

                break;
        }
    }
}
