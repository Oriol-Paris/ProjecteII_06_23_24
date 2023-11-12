using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Renderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();

        if (myRenderer == null)
        {
            Debug.Log("Renderer component not found on this GameObject.");
        }
    }
    public void ChangeColor(Color newColor)
    {
        if (myRenderer != null)
        {
            myRenderer.material.color = newColor;
        }
        else
        {
            Debug.Log("Renderer component not found. Color cannot be changed.");
        }
    }
}
