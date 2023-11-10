using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D bullet;
    private float timeDuration = 0.4f;
    private float timer;
    private bool shoot = true;
    [SerializeField]
    PlayerMovement player;
    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
            timer = timeDuration;
            shoot = true;
        }
        if (Input.GetMouseButton(0) || Gamepad.current.rightTrigger.IsActuated())
        {
            if (!player.godMode)
            {
                if (shoot)
                {
                    timer -= Time.deltaTime;
                    Instantiate(bullet, transform.position, player.transform.rotation);
                    shoot = false;
                }
            }
            else
                Instantiate(bullet, transform.position, transform.rotation);




        }
    }
}
