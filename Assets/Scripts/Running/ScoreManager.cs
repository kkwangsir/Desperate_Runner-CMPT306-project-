using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
	
	public Text scoreText;
	public Text highScoreText;
	
	public float scoreCount;
	public float highScoreCount;
	
	public float pointsPerSecond;
	
	public bool scoreIncreasing;
	

	// Use this for initialization
	void Start () {
		//display the hightest score when game starts
		if(PlayerPrefs.HasKey("HighScore")){
			
			highScoreCount = PlayerPrefs.GetFloat ("HighScore");
			
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (scoreIncreasing) {
		
			scoreCount += pointsPerSecond * Time.deltaTime;
		}
		
		if (scoreCount > highScoreCount) {
		
			highScoreCount = scoreCount;
			PlayerPrefs.SetFloat ("HighScore", highScoreCount);	//store the highest score when game over
		}
		
		//display scores
		scoreText.text = "Score: " + Mathf.Round(scoreCount); //math.round to show int
		highScoreText.text = "Highest Score: " + Mathf.Round(highScoreCount);
		
		
		if (scoreCount >= 200) {
		
			
			SceneManager.LoadSceneAsync ("BossStage");
			
			AsyncOperation scene = SceneManager.LoadSceneAsync ("RunningStage", LoadSceneMode.Additive);
			scene.allowSceneActivation = false;

		}

	}
	


	
	
	//add coin points to score
	public void AddScore(int pointsToAdd){
	
		scoreCount += pointsToAdd;
	}
}
