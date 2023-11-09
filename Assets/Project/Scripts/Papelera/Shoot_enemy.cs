using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_enemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D bullet;
    [SerializeField]
    private float timeDuration = 3f;
    [SerializeField]

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
            Instantiate(bullet, transform.position, transform.rotation);
            timer = timeDuration;
        }
    }
}
