using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLifes : MonoBehaviour {
	public float textWidth = 0;
	public float textHeight = 0;
	public Texture text;
	public int lifes = 5;

	// Use this for initialization
	void Start () {
		textWidth = text.width;
		textHeight = text.height;
	}
	
	// Update is called once per frame
	void OnGUI () {
		if (lifes > 0) {
			float posRectWidth = textWidth / 5 * lifes;
			Rect posRect = new Rect(50f,50f,posRectWidth, textHeight);
			Rect textRect = new Rect(0f,0f,1 / 5 * lifes, 1f);
			GUI.DrawTextureWithTexCoords(posRect, text, textRect);
			Debug.Log (posRectWidth);
		}
	}
}
