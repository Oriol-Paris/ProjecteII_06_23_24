using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class InteractableBarrel : WorldInteractable
{
    [SerializeField]
    private Rigidbody2D m_rb;
    [SerializeField]
    private Rigidbody2D grabbedBarrel;
    [SerializeField]
    private Rigidbody2D player;
    private Vector2 position;
    private Vector2 area;
    public InteractableBarrel(int maxHealth)
        : base(maxHealth) { }

    public override void Interact()
    {
        position = player.position;
        area.x = position.x - m_rb.position.x;
        area.y = position.y - m_rb.position.y;
        if (Input.GetKey(KeyCode.E) || Gamepad.current.aButton.IsActuated())
        {
            if(Mathf.Abs(area.x) < 1.1 && Mathf.Abs(area.y) < 1.6)
            {
                Destroy(this.gameObject);
                Instantiate(grabbedBarrel, player.transform.position, player.transform.rotation);
            }

            
        }
    }
}
