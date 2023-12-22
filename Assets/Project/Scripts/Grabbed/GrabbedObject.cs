using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbedObject : MonoBehaviour
{
    [SerializeField]
    protected GameObject player;
    [SerializeField]
    protected Rigidbody2D m_rb;

    protected virtual void Start()
    {
        Grab();
    }
    protected virtual void Update()
    {
        Track();
    }
    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected virtual void Grab()
    {

    }
    protected virtual void Track()
    {

    }
    protected virtual void Move()
    {

    }
}
