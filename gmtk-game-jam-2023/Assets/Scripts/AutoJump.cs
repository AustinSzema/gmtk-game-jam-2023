using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// THIS FILE HAS BEEN DEPRICATED, FUNCTIONALITY MOVED TO AutoMove.cs
/// </summary>
public class AutoJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;

    [SerializeField] private LayerMask whatIsGround;

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

        

        if (boxcast && grounded)
        {
            Jump();
        }*/
        /*
                grounded = Physics2D.Raycast(transform.position, Vector2.down, transform.localScale.y * 0.5f + 0.3f);

                Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2f), Vector2.right, Color.yellow, 100f);

                if(Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y/2f), Vector2.right, 2f, whatIsGround) && grounded){
                    Jump();
                }*/


    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

}
