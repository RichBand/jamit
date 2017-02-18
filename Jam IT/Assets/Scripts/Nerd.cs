using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nerd : MonoBehaviour {

	 public Transform goal;
     public Transform laserPosition;
     public Transform playerPosition;
     GameObject playerHitBox;
     GameObject laserDot;
     public int nerdSpeed;
     public int angryNerdSpeed = 5000;
     public int angryNerdTurningSpeed = 100;
     public bool nerdAngry = false;
     public bool nerdInterested = false;
     UnityEngine.AI.NavMeshAgent agent;
       void Start () {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            playerHitBox = GameObject.FindGameObjectWithTag("PlayerHitBox");
            laserDot = GameObject.FindGameObjectWithTag("LaserDot");
            playerPosition = playerHitBox.transform;
            laserPosition = laserDot.transform;
            goal = playerPosition;
        }
       void OnTriggerEnter(Collider other) {
<<<<<<< HEAD
        if (other.gameObject.tag == "LaserDot" &&  laserDot.GetComponent<LaserDotController>().laserActivated == true) {
            Debug.Log("NERD ANGRY!");
            nerdAngry = true;
            this.agent.speed = angryNerdSpeed;
            this.agent.angularSpeed = angryNerdTurningSpeed;
            goal = playerPosition;
        }
        else if(other.gameObject.tag == "LaserRange" && nerdAngry == false && laserDot.GetComponent<LaserDotController>().laserActivated == true) {
            Debug.Log("Nerd Interested");
            nerdInterested = true;
=======
        //Debug.Log(other.name);
        if (other.gameObject.tag == "LaserRange") {
            this.agent.speed = this.agent.speed * 3;
>>>>>>> 3357c89... battery and worspace scripts and UI
        }
       }
       void Update () {
           transform.eulerAngles=new Vector3(0,0,0);
           if (nerdInterested == true && laserDot.GetComponent<LaserDotController>().laserActivated == true) {
            agent.SetDestination(laserPosition.position);
           }
           else {
               agent.SetDestination(playerPosition.position);
           }
            
       }
}
