using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watson : MonoBehaviour {
	private float onSceneDuration = 0f;
	public GameObject center;
	public Vector3 size;

	// Use this for initialization
	void Start () {
		onSceneDuration = Random.Range(10f, 40.0f);
	}
	
	// Update is called once per frame
	void Update () {
		checkSceneTimer ();	
	}
	public void checkSceneTimer(){
		
		onSceneDuration--;
		if (onSceneDuration < 0) {
			gameObject.SetActive(false);
			Invoke( "RandomPosition" , Random.Range(0f, 5.0f) );		
		}
	}
	public void RandomPosition(){
		gameObject.SetActive(true);
		onSceneDuration = Random.Range(10f, 40.0f);
		if (center != null) {
			Debug.Log ("random");
			float x = center.transform.position.x + (Random.Range(-size.x / 2, size.x / 2 ));
			float z = center.transform.position.z + (Random.Range(-size.z / 2, size.z / 2 ));
			transform.position = new Vector3(x, transform.position.y, z);
			//Debug.Log (x + ", " + z + " ->" + transform.position);
		} else {
			Debug.Log ("Center empty for watson");
		}
	}

}
