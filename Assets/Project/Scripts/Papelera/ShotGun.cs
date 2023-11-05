using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun: MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D bullet;
    [SerializeField]
    private float timeDuration = 3f * 1f;
    [SerializeField]
    private int numberOfBullets = 5;

    private float gunAngle = 30.0f;
    private float timer;
    // Update is called once per frame

    private void Start()
    {
        timer = timeDuration;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Flash();
        }
    }
    private void Flash()
    {
        if(timer <= 0)
        {
            for(int i = 0; i < numberOfBullets; i++)
            {
                float angle = gunAngle *(i -(numberOfBullets -1) /2.0f);
                Quaternion rotation = Quaternion.Euler(0,0,angle);
                Instantiate(bullet, transform.position, rotation); 
            }
        }
    }
}
