using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private bool isOnPlatform = false;
    Vector2 firstPosition;
    Vector2 lastPosition;

    public float moveSpeed = 1f;

    private Rigidbody2D rb;

    private void Start()
    {
        firstPosition = transform.position;

        lastPosition = firstPosition - new Vector2(0, 1f);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isOnPlatform)
        {
            transform.position = Vector2.Lerp(transform.position, lastPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, firstPosition, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Fire") || collision.CompareTag("Water"))
        {
            isOnPlatform = true;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire") || collision.CompareTag("Water"))
        {
            isOnPlatform = false;
        }
    }
}
