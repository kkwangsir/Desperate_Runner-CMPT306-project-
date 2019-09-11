using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public float maxPos;

	public float speed;
	
	//public Main main;
	//public AudioSource boomSound;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (Main.gameOver == true) {

			return;
		}
		
		transform.position += transform.up * speed * Time.deltaTime;
		
		
		// Destroy bullets out of camera
		if (transform.position.y > maxPos) {
		
			Destroy (gameObject);
		}	
		
		if (transform.position.y < -maxPos) {

			Destroy (gameObject);
		}	
	}
	
	//
	void OnTriggerEnter2D (Collider2D col){
		
		if (tag == "playerBullet" && col.tag == "enemy") {
		
			//Destroy (col.gameObject);
			
			
			//boomSound.Play ();
			//audio.PlayOneShot (boom_sound);
			Destroy (gameObject);
			
			//Main.UpdateKillCount ();
			
		}

	}
}
