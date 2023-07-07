using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 1f;
    
    private bool movingRight = true;
    private float moveDirection = 1f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (movingRight)
        {
            rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        }
    }
}
