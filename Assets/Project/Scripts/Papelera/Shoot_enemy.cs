using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_enemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D bullet;
    private float timeDuration = 3f * 1f;
    private float timer;
    private float flashTimer;
    private float flashDuration = 1f;
    // Update is called once per frame

    private void Start()
    {
        ResetTimer();
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
    private void ResetTimer()
    {
        timer = timeDuration;
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
