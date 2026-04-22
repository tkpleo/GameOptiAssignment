using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float moveSpeedP1 = 5f;
    float moveSpeedP2 = 5f;
    float jumpForce = 8f;
    public GameObject player1;
    public GameObject player2;
    Rigidbody2D rbplayer1;
    Rigidbody2D rbplayer2;
    GroundCheck groundCheckP1;
    GroundCheck groundCheckP2;
    // Start is called before the first frame update
    void Start()
    {
        rbplayer1 = player1.GetComponent<Rigidbody2D>();
        rbplayer2 = player2.GetComponent<Rigidbody2D>();
        groundCheckP1 = player1.GetComponent<GroundCheck>();
        groundCheckP2 = player2.GetComponent<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && (groundCheckP1.isGrounded) && (groundCheckP2.isGrounded))
        {
            rbplayer1.velocity = new Vector2(rbplayer1.velocity.x, jumpForce);
            rbplayer2.velocity = new Vector2(rbplayer2.velocity.x, jumpForce);
            groundCheckP1.isGrounded = false;
            groundCheckP2.isGrounded = false;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            moveSpeedP1 = 0f;
        }
        else
        {
            moveSpeedP1 = 5f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            moveSpeedP2 = 0f;
        }
        else
        {
            moveSpeedP2 = 5f;
        }


    }

    private void FixedUpdate()
    {
        rbplayer1.velocity = new Vector2(horizontalInput * moveSpeedP1, rbplayer1.velocity.y);
        rbplayer2.velocity = new Vector2(horizontalInput * moveSpeedP2, rbplayer2.velocity.y);
    }
}
