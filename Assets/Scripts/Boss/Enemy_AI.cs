using UnityEngine;
using System.Collections;

public class Enemy_AI : MonoBehaviour {
	
	public float speed;

	
	
	public GameObject bullet;

	public float shootTimer;
	public float shootSpeed;
	
	public bool isMoveLeft;
	
	public float adjustBulletXpos;
	public float bulletAngle;
	
	
	private Animator myAnimator;
	
	Rigidbody2D myRigidbody;
	//public AudioSource isHit;
	
	// Use this for initialization
	
	
	//public Main main;
	
	//DecisionTree root;
	
	void Awake(){
	
		myAnimator = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();

	}
	
	void Start () {
		
		//BuildDecisionTree ();
		myAnimator = GetComponent<Animator> ();
		

		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		if (Main.gameOver == true) {

			return;
		}
		
		
		
		if (transform.position.y > 3) {
			transform.position = new Vector2 (transform.position.x, transform.position.y - speed * Time.deltaTime);
		} else {

			if (isMoveLeft == true) {

				MoveLeft ();
			} else {

				MoveRight ();
			}

			Shoot ();
		}
		
		if (Main.bossLife < 5) {
		
			BulletHell ();
		}
		
		
		if (transform.position.y < -11) {
		
			Destroy (gameObject);
		}
		
		
		myAnimator.SetFloat ("Speed", transform.position.x);
		myAnimator.SetFloat ("HP", Main.bossLife);
		
		//root.Search ();

	}
	

	
	
	
	void OnTriggerEnter2D (Collider2D col){
	
		if (col.tag == "playerBullet") {
		
			Main.UpdateBossLife ();
			
			
			
			Destroy (col.gameObject);
			
			//isHit.Play ();
		}
	}
	
	void MoveLeft(){
		
		transform.position = new Vector2 (transform.position.x - speed * Time.deltaTime, transform.position.y );
		
		if (transform.position.x < -3) {
		
			isMoveLeft = false;
		}
		
	}
	
	void MoveRight(){
		transform.position = new Vector2 (transform.position.x + speed * Time.deltaTime, transform.position.y );
		if (transform.position.x > 3) {

			isMoveLeft = true;
		}
	}
	
	void Flee(){
	
		transform.position = new Vector2 (transform.position.x, transform.position.y + speed * Time.deltaTime);
		
	}
	
	
	
	// Shooting bullet
	void Shoot(){

		if (shootTimer == 0) {

			for (int i = -1; i < 2; i++) {
				//create bullet
				Instantiate (bullet, new Vector2 (transform.position.x + adjustBulletXpos * i, transform.position.y - 1f), Quaternion.Euler (new Vector3 (0, 0, 180 + bulletAngle * i)));
			}
		}
		shootTimer += Time.deltaTime * shootSpeed;

		if (shootTimer > 1) {

			shootTimer = 0;
		}

	}
	


	void BulletHell(){
	
		if (shootTimer == 0) {

			for (int i = -3; i < 4; i++) {
				//create bullet
				Instantiate (bullet, new Vector2 (transform.position.x + adjustBulletXpos * i, transform.position.y - 1f), Quaternion.Euler (new Vector3 (0, 0, 180 + bulletAngle * i)));
			}
		}
		shootTimer += Time.deltaTime * shootSpeed;

		if (shootTimer > 1) {

			shootTimer = 0;
		}
	}
	
	/*
	 * 
	 * 
	
	// check bossHP
	bool CheckHealth(){
		Debug.Log("Check phealth");

		if (Main.bossLife>= 5f) {
			return true;
		} else {

			return false;
		}
	}

	// check playerHP
	bool CheckPlayerHP(){
		if (Main.playerLife >= 5f) {
			return true;
		} else {

			return false;
		}

	}
	
	/******  Build Decision Tree  *****
	
	void BuildDecisionTree(){
		
	
		DecisionTree isHealthyNode = new DecisionTree ();
		isHealthyNode.SetDecision (CheckHealth);
		
		DecisionTree isPlayerHpNode = new DecisionTree ();
		isPlayerHpNode.SetDecision (CheckPlayerHP);
		
		DecisionTree actFleeNode = new DecisionTree();
		actFleeNode.SetAction(Flee);
		
		DecisionTree actShoot = new DecisionTree ();
		actShoot.SetAction (Shoot);

		DecisionTree actBulletHellNode = new DecisionTree ();
		actBulletHellNode.SetAction (BulletHell);
		
		
		/******  Assemble Tree  *****
		isHealthyNode.SetLeft (isPlayerHpNode);
		isHealthyNode.SetRight (actBulletHellNode);
		
		isPlayerHpNode.SetLeft (actShoot);
		isPlayerHpNode.SetRight (actFleeNode);
		
		root = isHealthyNode;
		
	}*/
	
}
