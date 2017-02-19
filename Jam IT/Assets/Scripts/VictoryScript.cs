using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviour {
	
	bool mouseState = false;
    GameObject scene;
	
	void Awake(){
		if(PlayerPrefs.GetFloat("veteran") == 0){
			PlayerPrefs.SetFloat("veteran", 1.0f);
			PlayerPrefs.SetFloat("volume", 1.0f);
		}
		
		AudioListener.volume = PlayerPrefs.GetFloat("volume");	
		
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		
	}
	
	// Use this for initialization
	void Start () {
	
		scene = GameObject.Find("Scene");
		
		Rect tempR = new Rect(0,0,0,0);
		tempR.height = Screen.height;
		tempR.width = Screen.height * 2;
		tempR.x = Screen.width/2 - Screen.height;
			
		scene.GetComponent<GUITexture>().pixelInset = tempR;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!Input.GetMouseButton(0) && mouseState){
			PlayerPrefs.SetFloat("songTime", GetComponent<AudioSource>().time);
            SceneManager.LoadScene("Splash");
		}
		
		if(Input.GetMouseButton(0)){
			mouseState = true;	
		}
		else{
			mouseState = false;
		}
		
		Rect tempR = new Rect(0,0,0,0);
		tempR.height = Screen.height;
		tempR.width = Screen.height * 3;
		tempR.x = Screen.width/2 - tempR.width/2;
			
		//scene.GetComponent<GUITexture>().pixelInset = tempR;
		
	}
}
