using UnityEngine;
using System.Collections;

public class Boss_PlayerController : MonoBehaviour {
	
	public float maxXpos;
	public float maxYpos;

	public float speed;
	
	public GameObject bullet;
	
	public bool startShoot;
	public float shootTimer;
	public float shootSpeed;
	
	public AudioSource fireSound;
	
	//public Main main;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		

		
		if (Main.gameOver == true) {
		
			return;
		}
		//move left
		if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -maxXpos){

			transform.position = new Vector2 (transform.position.x - speed * Time.deltaTime, transform.position.y);

		}

		//move right
		if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < maxXpos){

			transform.position = new Vector2 (transform.position.x + speed * Time.deltaTime, transform.position.y);

		}

		//move up
		if(Input.GetKey(KeyCode.UpArrow) && transform.position.y < maxYpos){

			transform.position = new Vector2 (transform.position.x, transform.position.y + speed * Time.deltaTime);

		}

		//move down
		if(Input.GetKey(KeyCode.DownArrow) && transform.position.y > -maxYpos){

			transform.position = new Vector2 (transform.position.x, transform.position.y - speed * Time.deltaTime);

		}
		
		
		// Fire bullet
		if (Input.GetButtonDown ("Fire1")) {
			
			startShoot = true;
			fireSound.Play ();
		
		}
		else if(Input.GetButtonUp ("Fire1")){
			
			startShoot = false;
			shootTimer = 0;
			
		}
		
		if (startShoot == true) {
		
			Shoot ();
		}
		
		if (transform.position.y < -11) {

			PlayerDie ();
		}

	}
	
	
	// Clear object when hit by bullet
	void OnTriggerEnter2D (Collider2D col){

		if (col.tag == "enemy" || col.tag == "enemyBullet") {

			Destroy (col.gameObject);
			//Destroy (gameObject);
			
			PlayerDie ();

		}

	}
	
	
	// Shooting bullet
	void Shoot(){
		
		if (shootTimer == 0) {
			Instantiate (bullet, new Vector2 (transform.position.x, transform.position.y + 1), Quaternion.identity);
		}
		shootTimer += Time.deltaTime * shootSpeed;
		
		if (shootTimer > 1) {
		
			shootTimer = 0;
		}
		
	}
	
	
	// Player's death and respawn
	void PlayerDie(){
	
		transform.position = new Vector2 (0, -maxYpos);
		Main.UpdatePlayerLife ();
	}
	

}
