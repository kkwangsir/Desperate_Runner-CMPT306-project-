using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAfterTime : MonoBehaviour {
	
	[SerializeField]
	private float delayBeforeLoading = 10f;
	
	[SerializeField]
	private string sceneNameToLoad;
	
	private float timeElapsed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		timeElapsed += Time.deltaTime;
		if (timeElapsed > delayBeforeLoading) {
		
			SceneManager.LoadScene (sceneNameToLoad);
		}
	}
}
