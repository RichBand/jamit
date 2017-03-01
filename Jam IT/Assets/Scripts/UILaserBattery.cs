using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILaserBattery : MonoBehaviour {

    public UnityEngine.UI.Image FillImage;
    public LaserDotController Laser;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        FillImage.fillAmount = (float)Laser.batteryLevel / 100f;
    }
}
