using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemsController : MonoBehaviour
{
    Item item;

    public void RemoveItem()
    {
        InventoryManegement.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

   
}
