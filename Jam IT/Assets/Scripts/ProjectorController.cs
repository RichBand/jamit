using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ProjectorController : MonoBehaviour {
public float projectorCharge;
public float maxBrightness;
public Light projectorLight;
public bool projectorActivated = false;
private float projectorDuration = 10.0f;



	// Use this for initialization
	void Start () {
		//Transform projector = transform.Find("Projector");
		maxBrightness = projectorLight.intensity;
		projectorLight.intensity = 0f;
		projectorCharge = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(projectorCharge < 1.0f){
			projectorLight.intensity = projectorCharge * maxBrightness;
		}
		if(projectorCharge >= 1.0f) {
			Debug.Log("WE ARE FULLY CHARGED!");
			projectorActivated = true;

		}
		if(projectorActivated == true) {
			projectorDuration -= Time.deltaTime;
			Debug.Log(projectorDuration);
			if ( projectorDuration < 0 ) {
					projectorActivated = false;
					projectorCharge = 0f;
				Debug.Log("Projector off!");
				}
		}
		
		
	}
}
