using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GrabbedBarrel : GrabbedObject
{
    Vector2 movementDir;
    [SerializeField]
    float m_movementScale;
    [SerializeField]
    public ColorChanger colorChanger;
    [SerializeField]
    public Color originalColor;
    public bool grabbed = false;
    public bool explosive = false;
    protected override void Grab()
    {
        //if (explosive)
        //    colorChanger.ChangeColor(Color.red);
        //else
        //{
        //    colorChanger.ChangeColor(originalColor);
        //}
    }
    protected override void Track()
    {
        if (grabbed)
        {
            m_rb.position = player.position;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.up = direction;
        }
        else
            m_rb.transform.position = new Vector2(1000f, 1000f);
    }

    protected override void Move()
    {
    }
}
