using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watson : MonoBehaviour {
	private float timeActive = 0f;
	private readonly float timeActiveFinal = 50f;
	public GameObject center;
	public Vector3 size;
	public bool isActive = false ;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		timeActive = timeActiveFinal;
		//gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			checkSceneTimer ();
			Debug.Log ("check ");
		}
		Debug.Log ("isActive: " + isActive);
	}
	public void checkSceneTimer(){
		if (timeActive == timeActiveFinal) {
			Debug.Log("watson was initialized");
			transform.position = getRandomPosition ();
			UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
			agent.SetDestination(getRandomPosition());
			
		}

		timeActive--;

		if (timeActive < 0) {
			isActive = false;
			timeActive = timeActiveFinal;
			Debug.Log("watson inactive");
		}
	}
	//onSceneDuration = onSceneDurationFinal;
	//gameObject.SetActive(true);
	public Vector3 getRandomPosition(){
		float x = center.transform.position.x + (Random.Range(-size.x / 2, size.x / 2 ));
		float z = center.transform.position.z + (Random.Range(-size.z / 2, size.z / 2 ));
		return new Vector3(x, transform.position.y, z);
	}

}
