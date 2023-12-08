using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    Potion potion = new Potion();

    private GameObject buttonPrefab;

    private Transform buttonContainer;

    public List<Object> bagContent = new List<Object>();

    [SerializeField]
    private Canvas inventoryCanvas;

   public void AddObject (Object obj)
    {
        bagContent.Add(obj);

        GameObject buttonObject = Instantiate(buttonPrefab, buttonContainer);
        
    }


    // Start is called before the first frame update
    void Start()
    {
        bagContent.Add(potion);
        bagContent.Add(potion);
    }

    void OpenInventory()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
