using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDot : MonoBehaviour {
	public float horizontalSpeed = 1f;
	public float verticalSpeed = 1f;
	public bool laserActivated = false;
	public int batteryLevel;
	public Vector3 laserSize;
	GameObject playerObject;
	public Vector3 lastPosition = Vector3.zero;
	// Use this for initialization
	void Start () {
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
		batteryLevel = 100;
		laserSize = this.transform.localScale;
		playerObject = GameObject.FindGameObjectWithTag("Player");
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
		var playerPosition = playerObject.transform.position;
		//var h = horizontalSpeed * Input.GetAxis ("Mouse X");
 		//var v = verticalSpeed * Input.GetAxis ("Mouse Y");
		//Vector3 diff = this.transform.position - playerPosition;
		
		RaycastHit mouseCollision;
		Vector3 worldPoint = Vector3.zero;
		bool didItHit = false;
		Ray test = Camera.main.ScreenPointToRay(Input.mousePosition);
		if ( Physics.Raycast(test, out mouseCollision )) {
			{
				didItHit = true;
				worldPoint = mouseCollision.point;
			}

		}

		
		//var test = new Vector3(this.transform.position.x + h, this.transform.position.y, this.transform.position.z + v);
		lastPosition = this.transform.position;
		float distance = Vector3.Distance(worldPoint, playerPosition);//diff.magnitude;
		//float distance = Vector3.Distance(this.transform.position, playerPosition);//diff.magnitude;
		//Debug.Log(distance);
		
		if (distance <= 50 && didItHit) {
			this.transform.position = worldPoint;
		} else {
			//this.transform.position = lastPosition;
			this.transform.position = playerPosition + ((worldPoint - playerPosition).normalized * 50);
		}
	
	}
}
