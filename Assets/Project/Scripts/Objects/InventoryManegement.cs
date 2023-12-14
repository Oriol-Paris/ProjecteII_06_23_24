using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManegement : MonoBehaviour
{
    public static InventoryManegement Instance;
    public List<Item> items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;

    public Toggle enableRemove;

    public InventoryItemsController[] inventoryItems;

    private void Awake()
    {
        Instance = this;
    }

    

    public void Add(Item item)
    { items.Add(item); }

    public void Remove(Item item)
    { items.Remove(item); }

    public void RemoveAll()
    {
        items.Clear();
    }

    public void ListItems()
    {
        //Clean content

        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

            if(enableRemove.isOn)
                removeButton.gameObject.SetActive(true);

        }
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

    public void SetInventoryItems()
    {
        inventoryItems = itemContent.GetComponentsInChildren<InventoryItemsController>();

        for(int i = 0; i < items.Count; i++)
        {
            inventoryItems[i].AddItem(items[i]);
        }
    }
}
