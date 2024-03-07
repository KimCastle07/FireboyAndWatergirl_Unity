using UnityEngine;
using UnityEngine.UIElements;

public class Player1Controller : Player
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
    protected override void Init() => base.Init();

    protected override void Move() => base.Move();

    protected override void Jump() => base.Jump();

    protected override void HeadAnimation(float horizontal, float positionY) => base.HeadAnimation(horizontal, positionY);

    protected override void BodyAnimation(float horizontal) => base.BodyAnimation(horizontal);

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
        if (collision.gameObject.CompareTag("WaterLoad"))
        {
            Die();
        }
    }

}
