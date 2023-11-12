using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class InteractableBarrel : WorldInteractable
{
    [SerializeField]
    private GameObject explosion;
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
    private float cooldown = 0.25f;
    private bool isDead;
    public InteractableBarrel(int maxHealth)
        : base(maxHealth) { }

    protected void Start()
    {
        Character character = GetComponent<Character>();
        isDead = character.isDead;
    }
    public override void Interact()
    {
        Character character = GetComponent<Character>();
        isDead = character.isDead;
        if (character.isDead)
        {
            Debug.Log("Explode111111111111111111111111");
            StartCoroutine(Explosion());
            Destroy(this.gameObject, 10);
        }
        position = player.position;
        area.x = position.x - m_rb.position.x;
        area.y = position.y - m_rb.position.y;
        if (Input.GetKeyDown(KeyCode.E) || Gamepad.current.aButton.IsActuated())
        {
            if(Mathf.Abs(area.x) < 1.1 && Mathf.Abs(area.y) < 1.6)
            {
                Destroy(this.gameObject);
                gBarrel.grabbed = true;
                
            }
            
        }
        
    }
    IEnumerator Explosion()
    {
        GameObject explosionInstance = Instantiate(explosion, transform.position, transform.rotation);
        yield return new WaitForSeconds(cooldown);
        Destroy(explosionInstance);
    }
    public override void Die()
    {
        Destroy(this.gameObject, 2);
    }
}
