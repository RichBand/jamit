using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nerd : MonoBehaviour {

    public Material[] Skin;
    public SkinnedMeshRenderer Renderer;
	 public Transform goal;
     public Transform laserPosition;
     public Transform playerPosition;
     Transform RightProjectorPosition;
     Transform LeftProjectorPosition;
     Transform RearProjectorPosition;
     GameObject player;
	 GameObject watson;
     GameObject laserDot;
     GameObject RightProjectorAssembly;
     GameObject LeftProjectorAssembly;
     GameObject RearProjectorAssembly;
     public int nerdSpeed;
     public int angryNerdSpeed = 8;
     public int angryNerdTurningSpeed = 100;
     public bool nerdFollowingPlayer = true;
     public bool laserActivated = false;
	 public bool projectorActivated = false;
	public bool onRightProjectorPerimeter = false;
	public bool onLeftProjectorPerimeter = false;
	public bool onRearProjectorPerimeter = false;
	private float angryDuration = 5.0f;

     UnityEngine.AI.NavMeshAgent agent;
       void Start () {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
            laserDot = GameObject.FindGameObjectWithTag("LaserDot");
			watson = GameObject.FindGameObjectWithTag("Watson");
            RightProjectorAssembly = GameObject.FindGameObjectWithTag("RightProjectorAssembly");
            LeftProjectorAssembly = GameObject.FindGameObjectWithTag("LeftProjectorAssembly");
            RearProjectorAssembly = GameObject.FindGameObjectWithTag("RearProjectorAssembly");
            RightProjectorPosition = RightProjectorAssembly.transform;
            LeftProjectorPosition = LeftProjectorAssembly.transform;
            RearProjectorPosition = RearProjectorAssembly.transform;
            laserPosition = laserDot.transform;
            goal = playerPosition;

            // Assign random skin
            this.Renderer.sharedMaterials[0] = Skin[Random.Range(0, Skin.Length)];

            agent.updateRotation = true;
        }
       void OnTriggerEnter(Collider other) {
		activateGoal (other);
		if (other.gameObject.tag == "LaserDot") {
			StartNerdRage(laserDot.GetComponent<LaserDotController> ().laserActivated); 
		}
       }
	private void activateGoal(Collider other){
		//if eddison
		if (other.gameObject.tag == "RightProjectorAssembly") {
			onRightProjectorPerimeter = true;
		} else if (other.gameObject.tag == "LeftProjectorAssembly") {
			onLeftProjectorPerimeter = true;
			return;
		} else if (other.gameObject.tag == "RearProjectorAssembly") {
			onRearProjectorPerimeter = true;
			return;
		}
	}
	private Transform setGoal(){

		//if eddison

		if (watson.GetComponent<Watson> ().isActive == true) {
			Debug.Log ("neerd Looking for watson");
			return watson.transform;
		}
		if (laserActivated && laserDot.GetComponent<LaserDotController> ().laserActivated) {
			Debug.Log ("Following laser");
			return laserPosition;
		} else if (onRightProjectorPerimeter && RightProjectorAssembly.GetComponent<ProjectorController> ().projectorActivated == true) {
			Debug.Log ("RightProjectorAssembly");
			return RightProjectorPosition;
		} else if (onLeftProjectorPerimeter && LeftProjectorAssembly.GetComponent<ProjectorController> ().projectorActivated == true) {
			Debug.Log ("LeftProjectorAssembly");
			return LeftProjectorPosition;

		} else if (onRearProjectorPerimeter && RearProjectorAssembly.GetComponent<ProjectorController> ().projectorActivated == true) {
			Debug.Log ("RearProjectorAssembly");
			return RearProjectorPosition;
		}
		else {
			return playerPosition;
		}
		
	}
	public void setNerdAngry(bool angry = false){

		
	}
   void Update () {
		goal = setGoal();
		agent.SetDestination (goal.position);
   }
	float _nerdRageTimer;
	void StartNerdRage(bool angry)
	{
		// Reset timer
		_nerdRageTimer = 4f;
		// Stop existing (removes from stack)
		StopCoroutine("NerdRageRoutine");
		// Add a new copy back
		StartCoroutine(NerdRageRoutine(angry));
	}

	IEnumerator NerdRageRoutine(bool angry = false)
	{
		while(_nerdRageTimer >= 0) {
			// Subtrace frame time
			_nerdRageTimer -= Time.deltaTime;

			// This sends back the iterator (non blocking)
			yield return new WaitForEndOfFrame();
		}

		if (angry) {
			Debug.Log ("NERD ANGRY!");
			this.agent.speed = angryNerdSpeed;
			this.agent.angularSpeed = angryNerdTurningSpeed;
			angryDuration = 5.0f;
		} else {
			Debug.Log ("NERD calm!");
			this.agent.speed = 1;
			this.agent.angularSpeed = 10;

		}
	}
   
}