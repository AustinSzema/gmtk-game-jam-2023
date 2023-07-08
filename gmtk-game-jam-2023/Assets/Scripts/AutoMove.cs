using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    private bool _move = false;

    private float moveDirection = 1f;

    [SerializeField] private LayerMask whatIsWall;

    [SerializeField] private Transform raycastPosition;

    private void Start()
    {
        _move = false;
    }

    private void OnEnable()
    {
        _move = false;
        moveDirection = 1f;
        transform.rotation  = new Quaternion(0f, 0f, 0f, 0f);
    }

    void Update()
    {
        Debug.DrawRay(raycastPosition.position, transform.right, Color.yellow);

        if(Physics2D.Raycast(raycastPosition.position, transform.right, 1f))
        {
            moveDirection *= -1f;
            Debug.Log(moveDirection);
            if (moveDirection > 0f)
            {
                transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            }
            else
            {
                transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
            }
        }


        Move();

    }

    private void Move()
    {
        if (_move)
        {
         rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);           
        }
    }

    public void Play()
    {
        _move = true;
    }
}
