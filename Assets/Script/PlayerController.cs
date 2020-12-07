using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{

    public static PlayerController instance;

    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    private Animator anim;
    private SpriteRenderer theSR;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    public float bounceForce;

    public bool stopInput;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //左キー: -1、右キー: 1
		float x = Input.GetAxisRaw ("Horizontal");
		//左か右を入力したら
		if (x != 0) {
			//入力方向へ移動
			theRB.velocity = new Vector2 (x * moveSpeed, theRB.velocity.y);
			//localScale.xを-1にすると画像が反転する
			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;
		} else {
			//横移動の速度を0にしてピタッと止まるようにする
			theRB.velocity = new Vector2 (0, theRB.velocity.y);
		}

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

        if (isGrounded)
        {
        canDoubleJump = true;
        if (Input.GetMouseButtonDown(0))
            {
            anim.SetTrigger("shot");
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
        if (isGrounded)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }
            else
            {
                if (canDoubleJump)
                {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                canDoubleJump = false;
                }
            }
        }
        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }
}
