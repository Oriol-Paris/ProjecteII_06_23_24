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
    private Rigidbody2D objective;
    private Vector2 position;
    private Vector2 area;
    public InteractableBarrel(int maxHealth)
        : base(maxHealth) { }

    public override void Interact()
    {
        position = objective.position;
        area.x = position.x - m_rb.position.x;
        area.y = position.y - m_rb.position.y;
        if (Gamepad.current.aButton.IsActuated() || Input.GetButtonDown("e"))
        {
            if(Mathf.Abs(area.x) < 2 && Mathf.Abs(area.y) < 2)
            {
                Destroy(this.gameObject);
            }

            
        }
    }
}
