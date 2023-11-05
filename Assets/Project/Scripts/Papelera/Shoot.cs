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
    [SerializeField]
    PlayerMovement player;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Gamepad.current.rightTrigger.IsActuated())
        {
            if (!player.godMode)
            {
                if (timer > 0)
                    timer -= Time.deltaTime;
                else
                {
                    Instantiate(bullet, transform.position, transform.rotation);
                    timer = timeDuration;
                }
            }
            
            else
                Instantiate(bullet, transform.position, transform.rotation);
                
        }

        

    }
}
