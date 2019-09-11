using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;
	
	public GameObject pauseMenu;
	
	public void PauseGame(){
	
		Time.timeScale = 0f;	//0f = freeze game
		pauseMenu.SetActive (true);
	}
	
	public void ResumeGame(){
	
		Time.timeScale = 1f;	//1f = normal game speed
		pauseMenu.SetActive (false);
		
	}

	public void RestartGame(){

		Time.timeScale = 1f;
		pauseMenu.SetActive (false);
		
		FindObjectOfType<GameManager> ().Reset ();
		
	}

	public void QuitToMain(){

		Time.timeScale = 1f;
		Application.LoadLevel (mainMenuLevel);
	}
}
