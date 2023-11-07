using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun: MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D bullet;
    [SerializeField]
    private float timeDuration = 3f;
    [SerializeField]
    private int numberOfBullets = 5;

    [SerializeField]
    private float spread = 30.0f;
    // Update is called once per frame

    [SerializeField]
    private Transform target;

    private void Start()
    {
        InvokeRepeating("Flash", timeDuration, timeDuration);
    }

    private void Flash()
    {
        float playerToTargetAngle = Vector2.SignedAngle(Vector2.right, target.position - transform.position);
        for (int i = 0; i < numberOfBullets; i++)
        {
            float angle = Mathf.Lerp(-spread, spread, (float)i / (float)(numberOfBullets - 1));
            Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, angle + playerToTargetAngle));
        }
    }

}
