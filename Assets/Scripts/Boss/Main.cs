using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {
	
	//public static int killCount;
	public static int playerLife;
	public static int bossLife;
	
	public static GameObject result;
	
	public static bool gameOver;

	// Use this for initialization
	void Start () {
		
		
		//Screen.SetResolution (600,800, false);
		gameOver = false;
		result = GameObject.Find ("Result");
		result.SetActive (false);
		
		playerLife = 10;
		bossLife = 10;
		//killCount = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	
	/*
	public static void UpdateKillCount(){
	
		killCount += 1;
		GameObject.Find ("Kill").GetComponent<Text> ().text = "KILLED:" + killCount;
	}
	*/
	
	//player hp
	public static void UpdatePlayerLife(){

		if (playerLife > 0) {
			playerLife -= 1;
			GameObject.Find ("Player Life").GetComponent<Text> ().text = "HP: " + playerLife;
		} else {
			
			//result.SetActive (true);
			//result.GetComponent<Text> ().text = "OH NO!";
			gameOver = true;
		
			SceneManager.LoadScene ("EndVideo");

		}
	}
	
	//boss hp
	public static void UpdateBossLife(){

		if (bossLife > 0) {
			bossLife -= 1;
			
			
			GameObject.Find ("Boss Life").GetComponent<Text> ().text = "HP: " + bossLife;
		} else {
			
			//result.SetActive (true);
			//result.GetComponent<Text> ().text = "RELEASE MY WIFE!";
			gameOver = true;
			SceneManager.LoadScene ("EndVideo");
			

		}
	}
}
