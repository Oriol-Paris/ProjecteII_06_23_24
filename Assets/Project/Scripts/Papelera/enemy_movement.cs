using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rb;
    private float m_xMovement;
    private float m_yMovement;
    [SerializeField]
    private Rigidbody2D objective;
    [SerializeField]
    public float force = 50.0f;

    private Vector2 destination;

    // Update is called once per frame
    void Update()
    {
        destination = objective.position;

        m_xMovement = destination.x - m_rb.position.x;
        m_yMovement = destination.y - m_rb.position.y;
    }
    void FixedUpdate()
    {
            m_rb.AddForce(Vector2.right * m_xMovement * force, ForceMode2D.Impulse);
            m_rb.AddForce(Vector2.up * m_yMovement * force, ForceMode2D.Impulse);
    }
}
