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


    private void Awake()
    {
        inventoryCanvas.gameObject.SetActive(false);

        Potion potion = new Potion();

        AddObject(potion);
        AddObject(potion);

        //Asegurarse de que todos los botones estan vacios
    }

    public void AddObject (Object obj)
    {
        bagContent.Add(obj);


        //Buscar el primer botón vacío

        //cambiar el estado del boton, cambiar el nombre del botón
        //cambiar su color y lo más importante, el OnClick debe llamar a Use() y a Destroyer
       
            //Cambiar el Use()
            //obj.Use();
            Destroyer(obj);


        //Al eliminar a un objeto de la bolsa, los que estan detrás de este deben pasar a un puesto mayor
        //es decir, un puesto más cerca de 0
        //su color volvera a alpha 0, su texto en blanco una vez más...
    }

    private void Destroyer(Object obj)
    {
        bagContent.Remove(obj);
        Destroy(obj.gameObject);

        
       
    }
    public void OpenInventory()
    {
        inventoryCanvas.gameObject.SetActive(true);
    }
    public void CloseInventory()
    {
        inventoryCanvas.gameObject.SetActive(false);
    }
}
