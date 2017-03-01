using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	private Rigidbody m_rb;
	public Animator Anim;
    public Transform LaserPointerTip;
    public bool m_moveUp;
	public bool m_walking = false;
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

	public float workTimer = 0;
	private bool working = false;
	private bool interrupted = false;
	public int life = 100;

	void OnTriggerEnter(Collider other){
		if( other.gameObject.tag == "WorkspaceHitbox"  ){
			
			working = true;
		}
		if( other.gameObject.tag == "Nerd"  ){
			
			interrupted = true;
			life--;
			
		}
		if( other.gameObject.tag == "BatteryHitbox" || other.gameObject.tag == "Battery"  ){
			
			GameObject LaserDot = GameObject.FindGameObjectWithTag("LaserDot");
			LaserDot.GetComponent<LaserDotController>().batteryLevel = 100;
			
		}
	}
	void OnTriggerExit(Collider other){
		working = false;
	}
	public void addWorkTime (){

		// TODO: Add addWorking
		if(working && !interrupted){
			
			workTimer += Time.deltaTime;
			if(workTimer > 1){
				SceneManager.LoadScene("Victory");
			}
		}
		
	}


	public float playerVelocity = 500f;
	Vector3 m_rotation = new Vector3();
	// Use this for initialization
	void Start () {
		m_rb = GetComponent<Rigidbody>();
		Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		m_walking  = false;

		handleInput();
		handleRotation();
		handleAnimations();
		addWorkTime();
		checkLifes ();

	}
	void checkLifes(){
		if(life < 1){
			SceneManager.LoadScene("GameOver");	
		}
	}

	void FixedUpdate () {
		handleMovement();
	}
	private void handleInput () {

		
		if(Input.GetKey(KeyCode.W)) {
			m_turnup = true;
			m_walking = true;
         } else {
			 m_turnup = false;
		 }
		 if(Input.GetKey(KeyCode.S)) {
			m_turndown = true;
			m_walking = true;
         } else {
			 m_turndown = false;
		 }
         if(Input.GetKey(KeyCode.D)) {
			m_turnright = true;
			m_walking = true;
         } else {
			 m_turnright = false;
		 }
         if(Input.GetKey(KeyCode.A)) {
			m_turnleft = true;
			m_walking = true;
         } else {
			 m_turnleft = false;
		 }
		 if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) {
			m_turnup = false;
			m_turnleft = false;
			m_turnupleft = true;
			m_walking = true;
         } else {
			 m_turnupleft = false;
		 }
		 if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) {
			m_turndown = false;
			m_turnleft = false;
			m_turndownleft = true;
			m_walking = true;
         } else {
			 m_turndownleft = false;
		 }
         if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) {
			m_turndown = false;
			m_turnright = false;
			m_turndownright = true;
			m_walking = true;
         } else {
			 m_turndownright = false;
		 }
         if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)) {
			m_turnup = false;
			m_turnright = false;
			m_turnupright = true;
			m_walking = true;
         } else {
			 m_turnupright = false;
		 }
	}
	private void handleRotation() {
		if(m_turnup){
			Vector3 rotUp = new Vector3();
			rotUp.y = 1;
			m_rotation = rotUp;
		}
		else if(m_turndown){
			Vector3 rotDown = new Vector3();
			rotDown.y = 180;
			m_rotation = rotDown;
		}

		else if(m_turnleft){
			Vector3 rotLeft = new Vector3();
			rotLeft.y = 270;
			m_rotation = rotLeft;
		}
		else if(m_turnright){
			Vector3 rotRight = new Vector3();
			rotRight.y = 90;
			m_rotation = rotRight;
		}
		else if(m_turnupleft){
			Vector3 rotUp = new Vector3();
			rotUp.y = 315;
			m_rotation = rotUp;
		}
		else if(m_turndownleft){
			Vector3 rotDown = new Vector3();
			rotDown.y = 225;
			m_rotation = rotDown;
		}

		else if(m_turnupright){
			Vector3 rotLeft = new Vector3();
			rotLeft.y = 45;
			m_rotation = rotLeft;
		}
		else if(m_turndownright){
			Vector3 rotRight = new Vector3();
			rotRight.y = 135;
			m_rotation = rotRight;
		}
	}
	private void handleMovement() {
		transform.eulerAngles = m_rotation;
		transform.Translate(playerVelocity * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, playerVelocity * Input.GetAxis("Vertical") * Time.deltaTime,Space.World);
		
	}

	void handleAnimations() {
		if(m_walking) {
			Anim.SetBool("Walk", true);
			Anim.SetBool("Idle", false);
		} else {
			Anim.SetBool("Walk", false);
			Anim.SetBool("Idle", true);
		}
	}
}