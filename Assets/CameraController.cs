using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    protected float moveSpeed = 100f;
    [SerializeField]
    Teleport tp;
    [SerializeField]
    Teleport tp2;

    void Update()
    {
        if (tp.roomChanged)
        {
            MoveCamera(17.4f);
            if (transform.position.y >= 17.4f)
                tp.roomChanged = false;
        }

        if (tp2.roomChanged)
        {
            MoveCamera(34.1f);
            if (transform.position.y >= 33.1f)
                tp.roomChanged = false;
        }
    }

    protected void MoveCamera(float finalPosY)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, finalPosY, -30f), Time.deltaTime * moveSpeed);
    }
}
