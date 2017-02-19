using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorScreenController : MonoBehaviour {

	// Use this for initialization
	public GameObject laserDot;
	public Renderer rend;
	public Material projectorBlankImage;
	public Material projectorChargingImage;
	public Material projectorChargedImage;
	private bool screenIsCharging = false;
	private bool screenIsCharged = false;
	void Start () {
		laserDot = GameObject.FindGameObjectWithTag("LaserDot");
		rend = GetComponent<Renderer>();

	}
	void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "LaserDot" &&  laserDot.GetComponent<LaserDotController>().laserActivated == true && this.GetComponentInParent<ProjectorController>().projectorCharge < 1.0f) {
            this.GetComponentInParent<ProjectorController>().projectorCharge+=.11f; 
			screenIsCharging = true;
        }	
       }
	// Update is called once per frame
	void Update () {
		handleMaterials();
	}

	private void handleMaterials() {
		if(screenIsCharging) {
			rend.material = projectorChargedImage;
		}
	}
}
