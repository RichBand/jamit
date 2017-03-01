using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWorkTimer : MonoBehaviour {


    public Player PlayerController;
    public UnityEngine.UI.Text Output;

    // Update is called once per frame
    void Update () {
		if (!string.Equals(PlayerController.workTimer.ToString(), Output.text)) {
			Output.text = PlayerController.workTimer.ToString();
		}
    }
}
