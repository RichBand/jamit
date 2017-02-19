﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Rigidbody m_rb;
	private Animator Anim;
	public bool m_moveUp;
	public bool m_moveDown;
	public bool m_moveRight;
	public bool m_moveLeft;
	public bool m_turnleft;
	public bool m_turnright;
	public bool m_turnup;
	public bool m_turndown;
	public bool m_turnupleft;
	public bool m_turnupright;
	public bool m_turndownleft;
	public bool m_turndownright;

	public float playerVelocity = 1f;
	Vector3 m_rotation = new Vector3();
	// Use this for initialization
	void Start () {
		m_rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		handleInput();
		handleRotation();
		
	}

	void FixedUpdate () {
		handleMovement();
	}
	private void handleInput () {
		if(Input.GetKey(KeyCode.W)) {
			m_turnup = true;
         } else {
			 m_turnup = false;
		 }
		 if(Input.GetKey(KeyCode.S)) {
			m_turndown = true;
         } else {
			 m_turndown = false;
		 }
         if(Input.GetKey(KeyCode.D)) {
			m_turnright = true;
         } else {
			 m_turnright = false;
		 }
         if(Input.GetKey(KeyCode.A)) {
			m_turnleft = true;
         } else {
			 m_turnleft = false;
		 }
		 if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) {
			m_turnup = false;
			m_turnleft = false;
			m_turnupleft = true;
         } else {
			 m_turnupleft = false;
		 }
		 if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) {
			m_turndown = false;
			m_turnleft = false;
			m_turndownleft = true;
         } else {
			 m_turndownleft = false;
		 }
         if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) {
			m_turndown = false;
			m_turnright = false;
			m_turndownright = true;
         } else {
			 m_turndownright = false;
		 }
         if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)) {
			m_turnup = false;
			m_turnright = false;
			m_turnupright = true;
         } else {
			 m_turnupright = false;
		 }
	}
	private void handleRotation() {
		if(m_turnup){
			Vector3 rotUp = new Vector3();
			rotUp.y = 1;
			m_rotation = rotUp;
			Anim.SetBool("walk",true);
			Anim.SetBool("Idle",false);
		}
		else if(m_turndown){
			Vector3 rotDown = new Vector3();
			rotDown.y = 180;
			m_rotation = rotDown;
			Anim.SetBool("walk",true);
			Anim.SetBool("Idle",false);
		}

		else if(m_turnleft){
			Vector3 rotLeft = new Vector3();
			rotLeft.y = 270;
			m_rotation = rotLeft;
			Anim.SetBool("walk",true);
			Anim.SetBool("Idle",false);
		}
		else if(m_turnright){
			Vector3 rotRight = new Vector3();
			rotRight.y = 90;
			m_rotation = rotRight;
			Anim.SetBool("walk",true);
			Anim.SetBool("Idle",false);
		}
		else if(m_turnupleft){
			Vector3 rotUp = new Vector3();
			rotUp.y = 315;
			m_rotation = rotUp;
			Anim.SetBool("walk",true);
			Anim.SetBool("Idle",false);
		}
		else if(m_turndownleft){
			Vector3 rotDown = new Vector3();
			rotDown.y = 225;
			m_rotation = rotDown;
			Anim.SetBool("walk",true);
			Anim.SetBool("Idle",false);
		}

		else if(m_turnupright){
			Vector3 rotLeft = new Vector3();
			rotLeft.y = 45;
			m_rotation = rotLeft;
			Anim.SetBool("walk",true);
			Anim.SetBool("Idle",false);
		}
		else if(m_turndownright){
			Vector3 rotRight = new Vector3();
			rotRight.y = 135;
			m_rotation = rotRight;
			Anim.SetBool("walk",true);
			Anim.SetBool("Idle",false);
		}
	}
	private void handleMovement() {
		transform.eulerAngles = m_rotation;
		transform.Translate(playerVelocity * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, playerVelocity * Input.GetAxis("Vertical") * Time.deltaTime,Space.World);
	}
}
