using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicController : MonoBehaviour
{
	#region Properties
	public float playerSpeed;
	public float jumpingSpeed;
	public Transform shootingPoint;
	public GameObject bulletObject;
	public GameObject blackHoleObject;
	public float hurtCounter;
	public float shootingCounter;

	#region Ground check properties
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	#endregion

	#endregion

	#region Private
	private Rigidbody2D playerRigidbody;
	private Animator playerAnimator;
	private bool isPlayerOnGround;
	private float vHurtCounter;
	private float vShootingCounter;
	private bool facingRight;
	public int bulletsAmount = 10;
	private int bulletIndex;
	private WaitForSeconds wait;

	#region Animation Hash ID's
	private readonly int playerSpeedID = Animator.StringToHash("PlayerSpeed");
	private readonly int onGroundID = Animator.StringToHash("OnGround");
	private readonly int teleporID = Animator.StringToHash("Teleport");
	private readonly int hurtID = Animator.StringToHash("Hurt");
	private readonly int shootingID = Animator.StringToHash("Shoot");
	private readonly int shootingOnAirID = Animator.StringToHash("ShootOnAir");
	private readonly int isShootingID = Animator.StringToHash("IsShooting");
	private readonly int skillAttackID = Animator.StringToHash("SkillAttack");
	#endregion

	#endregion

	// Start is called before the first frame update.
	void Start()
    {
		playerRigidbody = GetComponent<Rigidbody2D>();
		playerAnimator = GetComponent<Animator>();
		facingRight = true;
		wait = new WaitForSeconds(1.5f);

		blackHoleObject.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
		isPlayerOnGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);		

		

		AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);

		// Always checking if player on Ground or not
		playerAnimator.SetBool(onGroundID, isPlayerOnGround);
		// Always setting the Player Speed to the Animator - Idle if Horizontal PlayerSpeed < 0.05f
		playerAnimator.SetFloat(playerSpeedID, Mathf.Abs(playerRigidbody.velocity.x));
		// Always setting the Player as NOT Shooting unless the player is shooting
		if (vShootingCounter <= 0f)
		{
			playerAnimator.SetBool(isShootingID, false);
		}
		else
		{
			vShootingCounter -= Time.deltaTime;
		}
	}

	private void FlipPlayer()
	{
		facingRight = !facingRight; // FacingRight becomes the opposite of the current value.
		transform.Rotate(0f, 180f, 0f);
	}

	private void Shoot()
	{
		bulletIndex = bulletIndex % bulletsAmount;
		GameObject bullet = BulletPool.bulletPoolInstance.GetBullet(bulletIndex++);
		bullet.transform.position = shootingPoint.position;
		bullet.transform.rotation = shootingPoint.rotation;
		bullet.SetActive(true);
	}
}
