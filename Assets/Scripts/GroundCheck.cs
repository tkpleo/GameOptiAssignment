using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = true;

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && collision.otherCollider == this.GetComponent<Collider2D>() && !isGrounded)
        {
            isGrounded = true;
            Debug.Log("Player has landed on the ground.");
        }
    }
}
