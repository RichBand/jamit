using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	public GameObject playButton;
	public GameObject backButton;
	public GameObject loading;
	
	bool mouseState = false;
	
	
	public Texture play1; 
	public Texture play2;
	public Texture back1;
	public Texture back2;
	
	// Use this for initialization
	void Start () {
		
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		
		playButton = GameObject.FindGameObjectWithTag("Play");
		playButton.GetComponent<GUITexture>().pixelInset = 
			new Rect(Screen.width * 0.028f, Screen.height * 0.5f, Screen.width*0.4f, Screen.height * 0.1f);
		
		backButton = GameObject.FindGameObjectWithTag("Back");
		backButton.GetComponent<GUITexture>().pixelInset = 
			new Rect(Screen.width * .63f, Screen.height * 0.5f, Screen.width*0.35f, Screen.height * 0.1f);
		
		loading = GameObject.FindGameObjectWithTag("Loading");
		loading.GetComponent<GUITexture>().pixelInset = new Rect(0,0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(InBox(Input.mousePosition, playButton.GetComponent<GUITexture>().pixelInset)){
			playButton.GetComponent<GUITexture>().texture = play2;
		}
		else{
			playButton.GetComponent<GUITexture>().texture = play1;
		}
		
		if(InBox(Input.mousePosition, backButton.GetComponent<GUITexture>().pixelInset)){
			backButton.GetComponent<GUITexture>().texture = back2;
		}
		else{
			backButton.GetComponent<GUITexture>().texture = back1;
		}
		
		if(!Input.GetMouseButton(0) && mouseState){
			if(InBox(Input.mousePosition, playButton.GetComponent<GUITexture>().pixelInset)){
				loading.GetComponent<GUITexture>().pixelInset = new Rect(0,0,Screen.width,Screen.height);
		
                    SceneManager.LoadScene("001_Gameplay");
				
			}
			else if(InBox(Input.mousePosition, backButton.GetComponent<GUITexture>().pixelInset)){
				loading.GetComponent<GUITexture>().pixelInset = new Rect(0,0,Screen.width,Screen.height);
                SceneManager.LoadScene("000_Splash");
			}
		}
		
		if(Input.GetMouseButton(0)){
			mouseState = true;	
		}
		else{
			mouseState = false;
		}
	}
					
					
	bool InBox(Vector2 spot, Rect box){
		if(spot.x > box.x && spot.x < box.x + box.width && spot.y > box.y && spot.y < box.y + box.height){
			return true;	
		}
		else{
			return false;	
		}
	}
}
