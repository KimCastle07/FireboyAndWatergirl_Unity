using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected Rigidbody2D rb;

    protected float speed = 5f;
    protected float jump = 5f;
    protected bool isJump;
    protected bool isGround;

    private void Awake()
    {
        Init();
    }

    void Update()
    {
        Move();
        Jump();
    }
    protected virtual void Init()
    {
        isJump = false;
        isGround = false;
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Move()
    {
        float h = Input.GetAxis("Horizontal");

        Vector2 vector = new Vector2(h, 0).normalized;

        vector = transform.TransformDirection(vector);

        Vector2 newVector = vector * speed;
        newVector.y += rb.velocity.y;
        rb.velocity = newVector;

    }

    protected virtual void Jump()
    {
        if (!isJump)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                isJump = true;
            }
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
        //openPopup<게임오버>;
    }
    
}
