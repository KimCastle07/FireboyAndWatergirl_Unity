using UnityEngine;

public class Stool : MonoBehaviour
{
    private float currentPosY;
    private float moveSpeed = 1f;
    private bool isStandPlatform = false;

    private Rigidbody2D rigid;

    private void Start()
    {
        currentPosY = transform.position.y;
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (false == isStandPlatform && currentPosY > transform.position.y)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Fire") || collision.collider.CompareTag("Water"))
        {
            isStandPlatform = true;
            rigid.gravityScale = 1f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Fire") || collision.collider.CompareTag("Water"))
        {
            isStandPlatform = false;
            rigid.gravityScale = 0f;
        }
    }
}
