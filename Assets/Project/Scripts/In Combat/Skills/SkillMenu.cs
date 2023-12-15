using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillMenu : MonoBehaviour
{
    public bool targetSelected = false;

    public bool skillMenuTop = false;

    private Button buttonPrefab;

    private RectTransform buttonContainer;

    public List<Object> bagContent = new List<Object>();

    [SerializeField]
    private Canvas inventoryCanvasTop;
    [SerializeField]
    private Canvas inventoryCanvasBottom;


    private void Awake()
    {
        inventoryCanvasTop.gameObject.SetActive(false);
        inventoryCanvasBottom.gameObject.SetActive(false);
    }

    public void AddObject(Object obj)
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
        //falla
        //Destroy(obj.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    public void OpenInventory()
    {
            if (skillMenuTop)
            {
                inventoryCanvasTop.gameObject.SetActive(true);
            }
            if (skillMenuTop == false)
            {
                inventoryCanvasBottom.gameObject.SetActive(true);
            }
    }
    public void CloseInventory()
    {
        if (skillMenuTop)
        {
            inventoryCanvasTop.gameObject.SetActive(false);
        }
        if (skillMenuTop == false)
        {
            inventoryCanvasBottom.gameObject.SetActive(false);
        }
    }
    public void changeSkillMenu()
    {
        skillMenuTop = !skillMenuTop;
    }
    public void setTargetSelectedTrue()
    {
        targetSelected = true;
    }
    public void setTargetSelectedFalse()
    {
        targetSelected = false;
    }
}
