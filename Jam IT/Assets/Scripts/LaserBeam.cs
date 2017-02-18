using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent (typeof(LineRenderer))]
 
public class LaserBeam : MonoBehaviour {
   	Vector3 playerPosition; 
	Vector3 laserTarget;
	LineRenderer laser;
 
	void Start () {
		laser = this.GetComponent<LineRenderer>();
		
	}
 
	void Update () {
			playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
			laserTarget = GameObject.FindGameObjectWithTag("LaserDot").transform.position;
			laser.SetPosition(0, playerPosition);
			laser.SetPosition(1, laserTarget);
	}
}
 