using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour {

    public Sprite Enabled;
    public Sprite Disabled;
    UnityEngine.UI.Button _button;
    // Use this for initialization
    void Start () {
        _button = GetComponent<UnityEngine.UI.Button>();
    }
	
	public void Toggle()
	{
		if ( _button.image.sprite == Enabled ) {
            _button.image.sprite = Disabled;
		
			// TODO: Insert Disable Sound Logic Here
		
        }
		else 
		{
			_button.image.sprite = Enabled;
			// TODO: Insert Enable Sound Logic Here
		}
	}
}
