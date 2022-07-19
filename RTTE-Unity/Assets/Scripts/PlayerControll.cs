using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpHeight = 5;

    public float groundedYPos;
    private bool isGrounded;

    private void Awake()
    {
        groundedYPos = transform.position.y + 0.1f;
    }

    private void Update()
    {
        if (transform.position.y <= groundedYPos)
            isGrounded = true;
        else
            isGrounded = false;
    }


    private void OnJump()
    {
        if (isGrounded)
        {
            rb.velocity = Vector3.up * jumpHeight;
            isGrounded = false;
        }
    }
}
