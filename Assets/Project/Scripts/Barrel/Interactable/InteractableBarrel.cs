using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class InteractableBarrel : WorldInteractable
{
    [SerializeField]
    private bool explosive = false;
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
    [SerializeField]
    public ColorChanger colorChanger;
    private bool isDead;
    private bool hasExploded = false;
    public InteractableBarrel(int maxHealth)
        : base(maxHealth) { }

    protected void Start()
    {
        Character character = GetComponent<Character>();
        isDead = character.isDead;
        if (explosive)
            colorChanger.ChangeColor(Color.red);
}
    public override void Interact()
    {
        Character character = GetComponent<Character>();
        isDead = character.isDead;
        if (character.isDead)
        {
            if (explosive)
            {
                Debug.Log("Explode111111111111111111111111");
                if (!hasExploded)
                {
                    StartCoroutine(Explosion());
                    hasExploded = true;
                }
            }
            else
                Destroy(this.gameObject);

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
                if (explosive)
                {
                    gBarrel.explosive = true;
                }
                else
                {
                    gBarrel.explosive = false;
                }
                
            }
            
        }
        
    }
    IEnumerator Explosion()
    {
        GameObject explosionInstance = Instantiate(explosion, transform.position, transform.rotation);
        yield return new WaitForSeconds(cooldown);
        Destroy(explosionInstance);
        Destroy(this.gameObject);
    }
    public override void Die()
    {
        Destroy(this.gameObject, 2);
    }
}
