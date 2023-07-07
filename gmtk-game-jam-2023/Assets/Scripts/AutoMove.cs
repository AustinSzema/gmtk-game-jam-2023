using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    
    private float moveDirection = 1f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            moveDirection *= -1f;
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }
}
