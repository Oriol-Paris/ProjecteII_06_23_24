using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class InteractableBarrel : WorldInteractable
{
    [SerializeField]
    private Rigidbody2D explosion;
    [SerializeField]
    private Rigidbody2D m_rb;
    [SerializeField]
    private Rigidbody2D grabbedBarrel;
    [SerializeField]
    private Rigidbody2D player;
    private Vector2 position;
    private Vector2 area;
    [SerializeField]
    private GrabbedBarrel gBarrel;
    [SerializeField]
    public Character IBarrel;
    public InteractableBarrel(int maxHealth)
        : base(maxHealth) { }

    public override void Interact()
    {
        if (IBarrel.isDead)
        {
            Debug.Log("Explode1");
            Instantiate(explosion, transform.position, transform.rotation);
        }
        position = player.position;
        area.x = position.x - m_rb.position.x;
        area.y = position.y - m_rb.position.y;
        if (Input.GetKey(KeyCode.E) || Gamepad.current.aButton.IsActuated())
        {
            if(Mathf.Abs(area.x) < 1.1 && Mathf.Abs(area.y) < 1.6)
            {
                Destroy(this.gameObject);
                gBarrel.grabbed = true;
                
            }
            
        }
        
    }
    public override void Die()
    {
        Destroy(this.gameObject);
    }
}
