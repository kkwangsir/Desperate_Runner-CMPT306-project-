using UnityEngine;
using System.Collections;

public class PickPoints : MonoBehaviour {
	
	public int scoreToGive;
	
	private ScoreManager theScoreManager;
	
	private AudioSource coinSound;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
		
		coinSound = GameObject.Find ("CoinSound").GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//pickup coins to get points
	void OnTriggerEnter2D (Collider2D other){
	
		if (other.gameObject.name == "Player") {
		
			theScoreManager.AddScore (scoreToGive);
			gameObject.SetActive (false);	//destroy coins which are picked
			
			if (coinSound.isPlaying) {
				coinSound.Stop ();
				coinSound.Play ();
			} else {
				coinSound.Play ();
			}
		}
	}
}
