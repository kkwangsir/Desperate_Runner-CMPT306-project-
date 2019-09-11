 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.Video;
 using UnityEngine.SceneManagement;
 
 public class LoadSceneAfterVideoEnded : MonoBehaviour
 { 

      public VideoPlayer videoPlayer; // Drag & Drop the GameObject holding the VideoPlayer component
   
     void Start() 
     {
		videoPlayer.loopPointReached += EndReached;
	
		
     }
	
     
		void EndReached(UnityEngine.Video.VideoPlayer vp)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene ("RunningStage");
		}      
  }