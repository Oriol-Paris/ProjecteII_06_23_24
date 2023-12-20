using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManegement : MonoBehaviour
{
    public GameObject inventoryCanvas;

    public static InventoryManegement Instance;
    public Dictionary<Item, int> items = new Dictionary<Item, int>();

    public Transform itemContent;
    public GameObject inventoryItem;

    public Toggle enableRemove;

    public InventoryItemsController[] inventoryItems;

    private void Awake()
    {
        Instance = this;
    }

    

    public void Add(Item item)
    {
        if (items.ContainsKey(item))
        {
            items[item]++;
            item.uiObject.UpdateAmount(items[item]);
            return;
        }

        UiItem uiItem = Instantiate(inventoryItem, itemContent).GetComponent<UiItem>();
        uiItem.Setup(item.icon, item.itemName, 1);

        item.uiObject = uiItem;

        items.Add(item, 1);
    }

    public void Remove(Item item)
    {
        Destroy(item.uiObject.gameObject);
        items.Remove(item);
    }

    public void RemoveAll()
    {
        items.Clear();
    }

    public void ListItems()
    {
        //Open Inventory
        inventoryCanvas.SetActive(true);
    }

    public void EnableItemsRemove()
    {
        if(enableRemove.isOn)
        {
            foreach(Transform item in itemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach(Transform item in itemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }
}
