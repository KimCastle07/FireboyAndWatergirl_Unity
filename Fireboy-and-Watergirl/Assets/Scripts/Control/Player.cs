using UnityEngine;

public abstract class Player : MonoBehaviour
{
    protected float speed = 5f;
    protected float jump = 5f;

    protected bool isJump;
    protected bool isGround;
    protected bool isPlayer1;

    protected Animator headAni;
    protected Animator bodyAni;

    protected Rigidbody2D rb;

    private void Awake()
        => Init();

    protected virtual void Init()
    {
        isJump = false;
        isGround = false;

        headAni = transform.Find("Head").GetComponent<Animator>();
        bodyAni = transform.Find("Body").GetComponent<Animator>();
        
        rb = GetComponent<Rigidbody2D>();
    }

    protected void Move(float KeyPress)
    {
        float horizontal = KeyPress;

        if (horizontal > -0.1f && horizontal < 0.1f)
        {
            headAni.SetBool("IsRun", false);
        }
        else
        {
            headAni.SetBool("IsRun", true);
        }

        Vector2 vector = new Vector2(horizontal, 0).normalized;

        vector = transform.TransformDirection(vector);

        Vector2 newVector = vector * speed;
        newVector.y += rb.velocity.y;
        rb.velocity = newVector;

        headAni.SetFloat("Run", horizontal);
    }

    protected void Jump(bool KeyPress)
    {
        if (false == isJump && KeyPress)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            isJump = true;
            
            headAni.SetTrigger("Jump");
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
            isGround = true;

            headAni.SetBool("IsAir", false);
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;

            headAni.SetBool("IsAir", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (true == isPlayer1 && collider.CompareTag("WaterLoad"))
        {
            Die();
        }

        if (false == isPlayer1 && collider.CompareTag("FireLoad"))
        {
            Die();
        }
    }

    protected abstract void Die();
}
