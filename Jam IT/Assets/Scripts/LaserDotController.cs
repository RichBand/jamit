using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDotController : MonoBehaviour {
	public float horizontalSpeed = 1f;
	public float verticalSpeed = 1f;
	public bool laserActivated = false;
	public int batteryLevel;
	public Vector3 laserSize;
	GameObject playerObject;
	GameObject laserBeamObject;
	GameObject laserImpactObject;
	public Vector3 lastPosition = Vector3.zero;
	// Use this for initialization
	void Start () {
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
		batteryLevel = 1000;
		
		playerObject = GameObject.FindGameObjectWithTag("Player");
		laserBeamObject = GameObject.FindGameObjectWithTag("LaserBeam");
		laserImpactObject = GameObject.FindGameObjectWithTag("LaserImpact");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && batteryLevel >= 0)
		{
			laserActivated = true;
			laserImpactObject.active = true;
			laserBeamObject.GetComponent<Renderer>().enabled = true;
			batteryLevel--;
			//Debug.Log("Battery Level: " + batteryLevel);
			
		}
		else {
			laserActivated = false;
			laserImpactObject.active = false;
			laserBeamObject.GetComponent<Renderer>().enabled = false;
			
		}
		
		var playerPosition = playerObject.transform.position;
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
		
		if (distance <= 5 && didItHit) {
			this.transform.position = worldPoint;
		} else {
			//this.transform.position = lastPosition;
			this.transform.position = playerPosition + ((worldPoint - playerPosition).normalized * 5);
		}
	
	}
}
