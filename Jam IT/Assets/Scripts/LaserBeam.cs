using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent (typeof(LineRenderer))]
 
public class LaserBeam : MonoBehaviour {
   	Vector3 playerPosition; 
	Vector3 laserTarget;
	LineRenderer laser;
    Transform _laserDot;
    Player _player;

    void Start () {
		laser = this.GetComponent<LineRenderer>();
        _laserDot = GameObject.FindGameObjectWithTag("LaserDot").transform;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
 
	void Update () {
        laser.SetPosition(0, _player.LaserPointerTip.position);
		laser.SetPosition(1, _laserDot.position);
	}
}
 