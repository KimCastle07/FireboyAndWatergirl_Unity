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
        Debug.Log(isJump);
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

        //headAni = transform.Find("Head").GetComponent<Animator>();
        //bodyAni = transform.Find("Body").GetComponent<Animator>();

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

    protected override void HeadAnimation(float horizontal, float positionY)
    {
        float x = headAni.transform.position.x;
        headAni.transform.Rotate(x switch
        {
            _ when x < headAni.transform.position.x => new Vector3(0, 180, 0),
            _ => Vector3.zero
        });

        if (isJump)
        {
            headAni.SetBool("isJump", true);
        }
        else
        {
            headAni.SetBool("isJump", false);
        }

        headAni.SetBool("isMove", horizontal switch
        {
            _ when horizontal != 0 => true,
            _ => false
        });

        headAni.SetInteger("Jump", positionY switch
        {
            _ when positionY < transform.position.y - 0.0001f => -1,
            _ when positionY > transform.position.y + 0.0001f => 1,
            _ => 0
        });
    }

    protected override void BodyAnimation(float horizontal)
    {
        float x = headAni.transform.position.x;
        bodyAni.transform.Rotate(x switch
        {
            _ when x < 0 => new Vector3(0, 180, 0),
            _ => Vector3.zero
        });

        bodyAni.SetBool("isJump", isJump);

        bodyAni.SetBool("isMove", horizontal switch
        {
            _ when horizontal != 0 => true,
            _ => false
        });
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
