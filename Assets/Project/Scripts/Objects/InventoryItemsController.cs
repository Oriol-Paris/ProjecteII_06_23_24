using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemsController : MonoBehaviour
{
    Item item;

    public Button removeButton;

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
            case Item.ItemType.POTION:

                break;
            case Item.ItemType.ATK_BUFF: 

                break;
        }
    }
}
