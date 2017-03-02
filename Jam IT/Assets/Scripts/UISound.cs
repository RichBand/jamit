using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour {

    public Sprite Enabled;
    public Sprite Disabled;
    UnityEngine.UI.Button _button;
	public AudioSource[] sources = new AudioSource[1];
    // Use this for initialization
    void Start () {
        _button = GetComponent<UnityEngine.UI.Button>();
	//	mainAudio = mainAudioSource.GetComponent<AudioSource> ();
	//	laserAudio = laserAudioSource.GetComponent<AudioSource> ();
    }
	
	public void Toggle()
	{
		if ( _button.image.sprite == Enabled ) {
            _button.image.sprite = Disabled;
			foreach (AudioSource source in sources) {
				source.volume = 0f;
			}
        }
		else 
		{
			_button.image.sprite = Enabled;
			foreach (AudioSource source in sources) {
				source.volume = 1f;
			}
		}
	}
}
