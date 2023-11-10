using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public int roomNum;
    public bool roomChanged;
    [SerializeField]
    protected Camera myCamera;
    [SerializeField]
    protected Canvas myCanvas;

    void Start()
    {
        roomNum = 1;
        roomChanged = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Character hm = collision.transform.GetComponent<Character>();
        if (hm != null)
        {
            if (hm.transform.position.y < 12.4f)
            {
                hm.gameObject.transform.position = new Vector2(0f, 12.4f);
                roomNum++;
                roomChanged = true;
                myCanvas.gameObject.SetActive(true);
                return;
            }
            else if (hm.transform.position.y < 30f)
            {
                hm.gameObject.transform.position = new Vector2(0f, 30f);
                roomNum++;
                roomChanged = true;
                myCanvas.gameObject.SetActive(false);
                return;
            }
        }
    }

   

}
