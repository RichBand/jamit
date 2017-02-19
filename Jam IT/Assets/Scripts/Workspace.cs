using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workspace : MonoBehaviour {
	private GameObject battery;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
	battery = other.gameObject;
		if( other.gameObject.tag == "BatteryHitbox"  ){	
			battery.GetComponent<Battery>().HiddenPosition();
			battery.GetComponent<Battery>().RandomPosition();
			Debug.Log("battery and worspace collide");
		}
	}
}
