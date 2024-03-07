using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected Rigidbody2D rb;

    protected float speed = 5f;
    protected float jump = 5f;
    protected bool isJump;
    protected bool isGround;

    [SerializeField] protected Animator headAni;
    [SerializeField] protected Animator bodyAni;
    protected float runCheak;
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
        headAni = transform.Find("Head").GetComponent<Animator>();
        bodyAni = transform.Find("Body").GetComponent<Animator>();

    }

    protected virtual void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float positionY = transform.position.y + 0.00001f;
        Vector2 vector = new Vector2(horizontal, 0).normalized;

        vector = transform.TransformDirection(vector);

        Vector2 newVector = vector * speed;
        newVector.y += rb.velocity.y;
        rb.velocity = newVector;
        HeadAnimation(horizontal, positionY);
        BodyAnimation(horizontal);
    }

    protected virtual void HeadAnimation(float horizontal, float positionY)
    {
        Debug.Log(horizontal);
        if (!isJump)
        {
            headAni.SetFloat("Run", horizontal);
            
        }

        if (horizontal == 0){ headAni.SetBool("RunCheck", false); }
        else { headAni.SetBool("RunCheck",true); }

        if (positionY > transform.position.y && isJump) 
        {
            headAni.SetBool("JumpDown", true);
        }
            headAni.SetBool("Jump", isJump);


    }

    protected virtual void BodyAnimation(float horizontal)
    {
        //if (Input.GetKey(KeyCode.LeftArrow)) { headAni.SetBool("L_Run", true); }
        //if (Input.GetKey(KeyCode.LeftArrow)) { headAni.SetBool("R_Run", true); }
        //bodyAni.SetBool("Jump", isJump);

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
