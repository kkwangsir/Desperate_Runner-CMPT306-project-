using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {
	
	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;
	public float distanceBetweenMin;
	public float distanceBetweenMax;
	
	
	private float platformWidth;
	
	public ObjectPooler[] theObjectPools;
	
	//public GameObject[] thePlatforms;
	private int platformSelector;
	private float[] platformWidths;
	
	
	//randomise platform height
	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	
	public float maxHeightChange;
	private float heightChange;


	//coins
	private CoinGenerator theCoinGenerator;
	public float randomCoinRate;
	
	//spikes
	public float randomSpikeRate;
	public ObjectPooler spikePool;
	
	
	// Use this for initialization
	void Start () {
		
		//platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;
		
		//add length control
		platformWidths = new float[theObjectPools.Length];
		
		for (int i = 0; i < theObjectPools.Length; i++) {
		
			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}
		
		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;
	
		theCoinGenerator = FindObjectOfType<CoinGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.x < generationPoint.position.x) {
			
			//randomise platforms
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
			
			platformSelector = Random.Range (0, theObjectPools.Length);
			
			//to randonly change platform height
			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);
			
			if (heightChange > maxHeight) {
			
				heightChange = maxHeight;
			
			} else if (heightChange < minHeight) {
			
				heightChange = minHeight;
			}
			
			
			//generate platforms
			transform.position = new Vector3 (transform.position.x + platformWidths[platformSelector] + distanceBetween, heightChange, transform.position.z);
		
			
			
			
			//Instantiate (/*thePlatform*/thePlatforms[platformSelector], transform.position, transform.rotation);
			
			//change to use obj pooler to generate platforms
			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject ();
			
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);
			
			//generate coins 'randomly'
			if (Random.Range (0f, 100f) < randomCoinRate) {
				theCoinGenerator.SpawnCoins (new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z));
			}
			
			//generate spikes randomlyy
			if (Random.Range (0f, 100f) < randomSpikeRate) {
				GameObject newSpike = spikePool.GetPooledObject ();
				
				float spikeXPosition = Random.Range (-platformWidths [platformSelector] / 2 + 1f, platformWidths [platformSelector] / 2 - 1f);
				
				
				Vector3 spikePosition = new Vector3 (spikeXPosition, 0.5f, 0f);
				
				newSpike.transform.position = transform.position + spikePosition;
				newSpike.transform.rotation = transform.rotation;
				newSpike.SetActive (true);
			}
			transform.position = new Vector3 (transform.position.x + platformWidths[platformSelector], transform.position.y, transform.position.z);
			
		}
	}
}
