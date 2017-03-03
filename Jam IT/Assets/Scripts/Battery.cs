using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour {
	public GameObject center;
	public Vector3 size;
	public float hoverHeight = 0.2f;

    public int Amount = 60;

    LaserDotController _laserController;

    // Use this for initialization
    void Start () {
        _laserController = GameObject.FindGameObjectWithTag("LaserDot").GetComponent<LaserDotController>();
    }
	
	// Update is called once per frame
	void Update () {
	}

	public void HiddenPosition(){
		gameObject.SetActive(false);
	}
	void OnTriggerEnter(Collider other){
		if( other.gameObject.tag == "Player"  ){
			HiddenPosition();
            _laserController.batteryLevel += Amount;
            Invoke( "RandomPosition" , 3f );
		}
		if( other.gameObject.tag == "LaserDot"  ){
			if (_laserController.laserActivated == true) {
				Debug.Log ("battery burned!");
				HiddenPosition();
				Invoke( "RandomPosition" , 6f );		
			}
		}
		if( other.gameObject.tag == "Table" || other.gameObject.tag == "Desktop" || other.gameObject.tag == "Workspace"   ){
				Debug.Log ("battery collide with " + other.gameObject.tag);
				//HiddenPosition();
				//Invoke( "RandomPosition" , 6f );		
		}
	}
	public void RandomPosition(){
		gameObject.SetActive(true);
		if (center != null) {
			float x = center.transform.position.x + (Random.Range(-size.x / 2, size.x / 2 ));
			float z = center.transform.position.z + (Random.Range(-size.z / 2, size.z / 2 ));
			transform.position = new Vector3(x, transform.position.y, z);
			//Debug.Log (x + ", " + z + " ->" + transform.position);
		} else {
			Debug.Log ("bad stuff");
		}
	}

}