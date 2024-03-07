using UnityEngine;

public class LeverMovingWall : MonoBehaviour
{
    private float moveSpeed = 1f;
    private float currentPosX;

    private Vector2 currentPos;

    private Lever lever;

    private void Start()
    {
        currentPos = transform.position;
        currentPosX = transform.position.x;
        lever = transform.parent.Find("Lever").GetComponent<Lever>();
    }

    private void Update()
    {
        if (true == lever.isLever && transform.position.x < currentPosX + transform.localScale.x / 2)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, currentPos, moveSpeed * Time.deltaTime);
        }
    }
}
