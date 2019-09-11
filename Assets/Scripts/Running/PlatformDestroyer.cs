﻿using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {
	
	public GameObject platformDestructionPoint;

	// Use this for initialization
	void Start () {
		
		platformDestructionPoint = GameObject.Find ("PlatformDsPoint");
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.x < platformDestructionPoint.transform.position.x) {
		
		
			//Destroy (gameObject);
			
			gameObject.SetActive (false);
		}
	}
}
