using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        OnCollisionEnter2D();
    }
    void OnCollisionEnter2D()
    {
        Destroy(this.gameObject, 10);
    }
}
