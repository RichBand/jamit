using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDot : MonoBehaviour {
	public float horizontalSpeed = 1f;
	public float verticalSpeed = 1f;
	public bool laserActivated = false;
	public int batteryLevel;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		batteryLevel = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			laserActivated = true;
		}
		else {
			laserActivated = false;
		}
		if (laserActivated == true) {
			batteryLevel--;
		}
		//Debug.Log("Battery level: " + batteryLevel);
		var playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
		var h = horizontalSpeed * Input.GetAxis ("Mouse X");
 		var v = verticalSpeed * Input.GetAxis ("Mouse Y");
		Vector3 diff = this.transform.position - playerPosition;
		float distance = diff.magnitude;
		if (distance > 50) {
			this.transform.position = playerPosition + (diff / distance) * 50;			
		}
		transform.Translate (h , 0, v);
	}
}
