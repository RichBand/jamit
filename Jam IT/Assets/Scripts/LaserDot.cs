using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDot : MonoBehaviour {
	public float horizontalSpeed = 1f;
	public float verticalSpeed = 1f;
	public bool laserActivated = false;
	public int batteryLevel;
	public Vector3 laserSize;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		batteryLevel = 100;
		laserSize = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			laserActivated = true;
			batteryLevel--;
			this.transform.localScale = Vector3.one;
		}
		else {
			laserActivated = false;
			this.transform.localScale = laserSize;
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
