using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float moveSpeed;
	private float moveSpeedStore;	//reset speed when restart
	public float speedMultiplier;
	
	//more speed control
	public float speedIncreaseMilestone;
	private float speedIncreaseMilestoneStore;
	
	private float speedMilestoneCount;
	private float speedMilestoneCountStore;
	
	
	
	public float jumpForce;
	
	//how long to jump
	public float jumpTime;
	private float jumpTimeCounter;
	
	private bool stopJump;
	private bool canDoubleJump;
	
	
	private Rigidbody2D myRigidbody;
	
	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;
	
	
	//private Collider2D myCollider;
	
	private Animator myAnimator;
	
	
	public GameManager theGameManager;
	
	public AudioSource jumpSound;
	public AudioSource deathSound;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		
		//myCollider = GetComponent<Collider2D> ();
		
		myAnimator = GetComponent<Animator> ();
		
		jumpTimeCounter = jumpTime;
		
		speedMilestoneCount = speedIncreaseMilestone;
		
		moveSpeedStore = moveSpeed;
		
		speedMilestoneCountStore = speedMilestoneCount;
		
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);
		
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		
		//increase movement speed
		if (transform.position.x > speedMilestoneCount) {
		
			speedMilestoneCount += speedIncreaseMilestone;
			
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			
			moveSpeed = moveSpeed * speedMultiplier;
		}
		
		
		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);
		
		//jump
		if (Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButton (0))
		{
			
			if (grounded) 
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				stopJump = false;
				jumpSound.Play ();
			}
			
			//double jump
			if(!grounded && canDoubleJump){
				
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter = jumpTime;
				stopJump = false;
				canDoubleJump = false;
				jumpSound.Play ();
				
			}
		}
		
		if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) && !stopJump) {
		
			if (jumpTimeCounter > 0) {
			
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			
			}
		
		}
		
		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButton (0)) {
		
			jumpTimeCounter = 0;
			stopJump = true;
		}
		
		if (grounded) {
		
			jumpTimeCounter = jumpTime;
			canDoubleJump = true;
		}
		
		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
	
	}
	
	void OnCollisionEnter2D(Collision2D other){
	
		if (other.gameObject.tag == "killbox") {
		
			
			theGameManager.RestartGame ();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
			deathSound.Play ();
			
		}
	}
}
