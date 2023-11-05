using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Rigidbody2D objective;
    private Vector2 destination;
    // Update is called once per frame
    void Update()
    {
        Vector2 playerPosition = objective.position;
        Vector2 direction = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);
        transform.right = direction;
    }
}
