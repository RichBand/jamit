using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWatsonButton : MonoBehaviour {

	public Sprite Enabled;
	public Sprite Disabled;
	private GameObject watson;
	private GameObject battery;
	private GameObject player;
	UnityEngine.UI.Button _button;
	// Use this for initialization
	void Start () {
		_button = GetComponent<UnityEngine.UI.Button>();
		watson = GameObject.FindGameObjectWithTag("Watson");
		battery = GameObject.FindGameObjectWithTag("LaserDot");
		player = GameObject.FindGameObjectWithTag("Player");
	}
	void Update () {
		if (watson.GetComponent<Watson>().isActive == false) {
			_button.image.sprite = Disabled;
			Debug.Log ("Disabled by update");
		}
	}

	public void Toggle()
	{
		Debug.Log("Watson Enabled: " +  watson.GetComponent<Watson>().isActive);
		if (watson.GetComponent<Watson>().isActive == true) {
			_button.image.sprite = Disabled;
			Debug.Log ("Disabled");
			watson.GetComponent<Watson> ().isActive = false;
		}
		else 
		{ 
			Debug.Log ("Enabled");
			_button.image.sprite = Enabled;
			watson.GetComponent<Watson> ().isActive = true;
			player.GetComponent<Player> ().health -= 15;
			battery.GetComponent<LaserDotController> ().batteryLevel -= 10;

		}
	}
}
