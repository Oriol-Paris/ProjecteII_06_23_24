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


        //Buscar el primer bot�n vac�o

        //cambiar el estado del boton, cambiar el nombre del bot�n
        //cambiar su color y lo m�s importante, el OnClick debe llamar a Use() y a Destroyer
       
            //Cambiar el Use()
            //obj.Use();
            Destroyer(obj);


        //Al eliminar a un objeto de la bolsa, los que estan detr�s de este deben pasar a un puesto mayor
        //es decir, un puesto m�s cerca de 0
        //su color volvera a alpha 0, su texto en blanco una vez m�s...
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
