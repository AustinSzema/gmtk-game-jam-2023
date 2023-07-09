using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = -200f;
    [SerializeField] private Rigidbody2D playerRB;

    void Update()
    {
        if (playerRB.velocity != Vector2.zero)
        {
            transform.Rotate(Vector3.forward * Mathf.Abs(playerRB.velocity.x) * rotationSpeed * Time.deltaTime);

        }
    }
}
