using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {
	
	public GameObject pooledObject;
	
	public int pooledAmount;
	
	List <GameObject> pooledObjects;

	// Use this for initialization
	void Start () {
		
		pooledObjects = new List <GameObject> ();
		
		
		//fill the obj
		for (int i = 0; i < pooledAmount; i++) {
		
			GameObject obj = (GameObject) Instantiate (pooledObject);
			obj.SetActive (false);
			
			pooledObjects.Add (obj);
		}
	
	}
	
	//looking for gameobj and add to pool
	public GameObject GetPooledObject (){
	
		for (int i = 0; i < pooledObjects.Count; i++) {
		
			if (!pooledObjects[i].activeInHierarchy) {
			
				return pooledObjects[i];
			}

		}
		GameObject obj = (GameObject) Instantiate (pooledObject);
		obj.SetActive (false);

		pooledObjects.Add (obj);
		return obj;

	
	
	}
	// Update is called once per frame
	void Update () {
	
	}
}
