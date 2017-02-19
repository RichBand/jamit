using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorScreenController : MonoBehaviour {

	// Use this for initialization
	public GameObject laserDot;
	void Start () {
		laserDot = GameObject.FindGameObjectWithTag("LaserDot");
	}
	void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "LaserDot" &&  laserDot.GetComponent<LaserDotController>().laserActivated == true && this.GetComponentInParent<ProjectorController>().projectorCharge < 1.0f) {
            this.GetComponentInParent<ProjectorController>().projectorCharge+=.11f; 
        }
       }
	// Update is called once per frame
	void Update () {
		
	}
}
