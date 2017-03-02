using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayersLife : MonoBehaviour {

    public UnityEngine.UI.Image FillImage;
    public Player PlayerController;

	
	// Update is called once per frame
	void Update () {
        FillImage.fillAmount = (float)PlayerController.healt / 100f;
    }
}
