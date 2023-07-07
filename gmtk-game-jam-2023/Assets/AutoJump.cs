using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
   
    private bool grounded;

    private void Update()
    {

        /*RaycastHit2D boxcast = Physics2D.BoxCast(

            //Starting point of box
            Vector2.zero,

            //Size of the box
            new Vector2(2f, 2f),

            //Angle of box,
            0f,

            //Direction to cast
            Vector2.right,

            //Distance to cast
            5f

        );

        grounded = Physics2D.Raycast(transform.position, Vector2.down, transform.localScale.y * 0.5f + 0.3f);

        if (boxcast && grounded)
        {
            Jump();
        }*/



    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

}
