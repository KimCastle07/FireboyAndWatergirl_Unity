using UnityEngine;

public class Player2Controller : Player
{
    protected override void Init()
    {
        base.Init();
        
        isPlayer1 = false;
    }

    private void Update()
    {
        Move(Input.GetAxis("HorizontalPlayer2"));
        Jump(Input.GetKeyDown(KeyCode.W));
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }
}
