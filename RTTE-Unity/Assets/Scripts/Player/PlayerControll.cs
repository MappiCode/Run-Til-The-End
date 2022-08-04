using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpHeight = 5;

    private bool isGrounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
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
