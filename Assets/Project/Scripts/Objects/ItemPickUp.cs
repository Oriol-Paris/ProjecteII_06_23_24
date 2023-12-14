using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;

    void PickUp()
    {
        InventoryManegement.Instance.Add(item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        PickUp();
    }
}
