using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float playerVelocity = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles=new Vector3(0,0,0);
		transform.Translate(playerVelocity * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, playerVelocity * Input.GetAxis("Vertical") * Time.deltaTime);
	}
}
