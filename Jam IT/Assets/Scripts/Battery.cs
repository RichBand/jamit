using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour {
	public GameObject center;
	public Vector3 size;
	public float hoverHeight = 1f;
	public GameObject BatteryPrefab;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void HiddenPosition(){
		gameObject.SetActive(false);
	}
	void OnTriggerEnter(Collider other){

		if( other.gameObject.tag == "PlayerHitbox"  ){
			HiddenPosition();
			Invoke( "RandomPosition" , 3f );		
		}
	}
	public void RandomPosition(){
		gameObject.SetActive(true);
		if (center != null) {
			Debug.Log ("random");
			float x = center.transform.position.x + (Random.Range(-size.x / 2, size.x / 2 ));
			float z = center.transform.position.z + (Random.Range(-size.z / 2, size.z / 2 ));
			transform.position = new Vector3(x, center.transform.position.y, z);
			Debug.Log (x + ", " + z + " ->" + transform.position);
		} else {
			Debug.Log ("bad stuff");
		}
	}

}
