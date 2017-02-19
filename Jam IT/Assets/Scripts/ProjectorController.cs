using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ProjectorController : MonoBehaviour {
public float projectorCharge;
public float maxBrightness;
private Light projectorLight;


	// Use this for initialization
	void Start () {
		Transform projector = transform.Find("Projector");
		projectorLight = projector.GetComponent<Light>();
		maxBrightness = projectorLight.intensity;
		projectorLight.intensity = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(projectorCharge < 1.0f){
			projectorLight.intensity = projectorCharge * maxBrightness;
		}
		if(projectorCharge >= 1.0f) {
			Debug.Log("WE ARE FULLY CHARGED!");
		}
		
	}
}
