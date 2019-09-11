using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	
	public string playGameLevel;
	

	public void PlayGame(){
	
		SceneManager.LoadScene ("StartVideo");
	}
	
	public void QuitGame(){
	
		Application.Quit ();
	}

}
