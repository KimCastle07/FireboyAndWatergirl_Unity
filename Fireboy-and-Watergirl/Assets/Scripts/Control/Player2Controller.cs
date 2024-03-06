using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : Player
{
    private void Awake()
    {
        Init();
    }
    private void Update()
    {
        Move();
        Jump();
    }

    protected override void Move()
    {
        float h = Input.GetAxis("HorizontalPlayer2");

        Vector2 vector = new Vector2(h, 0).normalized;

        vector = transform.TransformDirection(vector);

        Vector2 newVector = vector * speed;
        newVector.y += rb.velocity.y;
        rb.velocity = newVector;

    }
    protected override void Jump()
    {
        if (!isJump)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                isJump = true;
            }
        }
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
            isGround = true;
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireLoad"))
        {
            Die();
        }
    }
}
