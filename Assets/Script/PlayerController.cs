using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{

    public static PlayerController instance;

    public float moveSpeed;

		public float defaultMoveSpeed;
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

    public GameObject bullet,weapon1,weapon2;

		public GameObject chargeBullet;
    public Transform firePoint,firePoint2;

    public Transform thePlayer;

		public float shotCharge;

		public bool isCharged;

		public float miniShotX,miniShotY;

		public float chargeShotX,chargeShotY;

		public float slideLength;

		private float slideCount;

		public float slideSpeed;

		public bool isRuder;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
				moveSpeed = defaultMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
		if(!PauseMenu.instance.isPaused && !stopInput)
		{
			if (knockBackCounter <= 0)
				{
					if (slideCount >= 0)
					{
						slideCount -= Time.deltaTime;
						moveSpeed = slideSpeed;
					}else
					{
						moveSpeed = defaultMoveSpeed;
					}
					
							//左キー: -1、右キー: 1
					float x = (Input.GetAxisRaw ("Horizontal")) * 0.7f;
					//左か右を入力したら
					if (x != 0) {
						//入力方向へ移動
						
						theRB.velocity = new Vector2 (x * moveSpeed, theRB.velocity.y);
						//localScale.xを-1にすると画像が反転する
						Vector2 temp = transform.localScale;
						temp.x = x;
						transform.localScale = temp;

							//スライディング
							if (Input.GetButtonDown("Dash"))
							{
								if(isGrounded)
								{
								slideCount = slideLength;
								anim.SetTrigger("slide");
								AudioManeger.instance.PlaySFX(12);
								}
								
							}
					} 
					else {
						//横移動の速度を0にしてピタッと止まるようにする
						theRB.velocity = new Vector2 (0, theRB.velocity.y);
					}
					//梯子上り下り
					if(isRuder == true)
					{
						float y = (Input.GetAxisRaw ("Vertical")) * 0.7f;
						theRB.gravityScale = 0;

						//左か右を入力したら
						if (y != 0) 
						{
							//入力方向へ移動
							theRB.velocity = new Vector2 (0 , y * moveSpeed);
						}
						else {
						//横移動の速度を0にしてピタッと止まるようにする
						theRB.velocity = new Vector2 (theRB.velocity.x, 0);
					}
					}
				


							isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

							if (isGrounded)
							{
							canDoubleJump = true;
							}
							
							//ジャンプ
							if (Input.GetButtonDown("Jump"))
							{
							if (isGrounded)
									{
											theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
											AudioManeger.instance.PlaySFX(0);
									}
									else
									{   //ダブルジャンプ
											if (canDoubleJump)
											{
											theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
											canDoubleJump = false;
											AudioManeger.instance.PlaySFX(0);
											}
									}
							}
								//チャージ開始
							if (Input.GetButton("Fire1"))
							{
									shotCharge += 1;
							}else
							{
								shotCharge --;
							}
							//弾を打つ
							if (Input.GetButtonDown("Fire1"))
									{
											anim.SetTrigger("shot");
											var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
													newBullet.transform.localScale = new Vector3 (miniShotX * thePlayer.localScale.x,miniShotY,0);
													AudioManeger.instance.PlaySFX(1);
													shotCharge = 0;
													
									}
							//チャージショット
							if  (Input.GetButtonUp("Fire1") && shotCharge >= 140 )
							{

									anim.SetTrigger("shot");
									var newBullet = Instantiate(chargeBullet, firePoint.position, firePoint.rotation);
									newBullet.transform.localScale = new Vector3 (chargeShotX * thePlayer.localScale.x,chargeShotY,0);
									AudioManeger.instance.PlaySFX(6);
									shotCharge = 0;
									
							}
							//チャージ音
							if (shotCharge == 50)
							{
									AudioManeger.instance.PlaySFX(9);
							}
							//チャージエフェクト（点滅）
							if (shotCharge >= 60)
							{
									isCharged = true;
							}else
							{
								isCharged = false;
								theSR.color =  new Color(1f,1f,1f,1f);
							}

							//武器チェンジ
							if (Input.GetButtonDown("Weapon Change"))
							{
								UIController.instance.WeaponChange();
								AudioManeger.instance.PlaySFX(17);
							}
							//特殊武器
							if(PlayerhealthController.instance.MP1 >= 0)
							{
								//ブラックホール
								if (UIController.instance.weapon1 == 1 && Input.GetButtonDown("Fire2") )
										{
												anim.SetTrigger("shot");
												var newBullet = Instantiate(weapon1, firePoint.position, firePoint.rotation);
														newBullet.transform.localScale = new Vector3 (1 * thePlayer.localScale.x,1,0);
														AudioManeger.instance.PlaySFX(15);
														shotCharge = 0;
														PlayerhealthController.instance.MP1 -- ;
														
										}
								//ウィンド
								if (UIController.instance.weapon1 == 2 && Input.GetButtonDown("Fire2") )
										{
												anim.SetTrigger("shot");
												var newBullet = Instantiate(weapon2, firePoint2.position, firePoint2.rotation);
														newBullet.transform.localScale = new Vector3 (1 * thePlayer.localScale.x,0.8f,0);
														AudioManeger.instance.PlaySFX(23);
														shotCharge = 0;
														PlayerhealthController.instance.MP2 -- ;
														
										}
							}
				}	else
							{
									knockBackCounter -= Time.deltaTime;
									if (!theSR.flipX)
									{
											theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
									}
									else
									{
											theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
									}
							}
							
					//ダッシュモーション
					anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));

					//ジャンプモーション
					anim.SetBool("isGrounded", isGrounded);
					//梯子モーション
					anim.SetFloat("climbSpeed", Mathf.Abs(theRB.velocity.y));


		}



					
    }

  public void KnockBack()
  {
    knockBackCounter = knockBackLength;
    theRB.velocity = new Vector2(0f, knockBackForce);

    anim.SetTrigger("hurt");
  }

	void FixedUpdate ()
	{
		if(isCharged){
			float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
			theSR.color =  new Color(1f,1f,1f,level);
		}
	}

  private void OnTriggerEnter2D(Collider2D other)
	{
    if (other.tag == "Ruder")
		{
      anim.SetBool("isRuder", true);
			isRuder =true;
			theRB.gravityScale =0.5f;
		}
	}
  private void OnTriggerExit2D(Collider2D other)
	{
    if (other.tag == "Ruder")
    {
      anim.SetBool("isRuder", false);
      isRuder = false;
      theRB.gravityScale = 5f;
    }
	}


}
