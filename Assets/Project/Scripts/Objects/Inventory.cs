using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    Potion potion = new Potion();

    private Button buttonPrefab;

    private RectTransform buttonContainer;

    public List<Object> bagContent = new List<Object>();

    [SerializeField]
    private Canvas inventoryCanvas;

   public void AddObject (Object obj)
    {
        bagContent.Add(obj);

        Button buttonObject = Instantiate(buttonPrefab, buttonContainer);
        Button button = buttonObject.GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            //obj.Use();
            Destroyer(obj);
        });

    }

    private void Destroyer(Object obj)
    {
        bagContent.Remove(obj);
        Destroy(obj.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        AddObject(potion);
        AddObject(potion);
    }

    public void OpenInventory()
    {
        inventoryCanvas.enabled = true;
    }
    private void CloseInventory()
    {
        inventoryCanvas.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}