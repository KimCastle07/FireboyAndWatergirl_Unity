using UnityEngine;

public class Player1Controller : Player
{
    protected override void Init()
    {
        base.Init();

        isPlayer1 = true;
    }

    private void Update()
    {
        Move(Input.GetAxis("Horizontal"));
        Jump(Input.GetKeyDown(KeyCode.UpArrow));
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
