using UnityEngine;

public class StoolMovingWall : MonoBehaviour
{
    private float moveSpeed = 1f;
    private float currentPosX;

    private Vector2 currentPos;

    private Stool stool;

    private void Start()
    {
        currentPos = transform.position;
        currentPosX = transform.position.x;
        stool = transform.parent.Find("Stool").GetComponent<Stool>();
    }

    private void Update()
    {
        if (true == stool.isStandWall && transform.position.x < currentPosX + transform.localScale.x / 2)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, currentPos, moveSpeed * Time.deltaTime);
        }
    }
}
