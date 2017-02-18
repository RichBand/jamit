using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nerd : MonoBehaviour {

	 public Transform goal;
     public Transform laserPosition;
     public Transform playerPosition;
     public int nerdSpeed;
     public int angryNerdSpeed = 5000;
     public int angryNerdTurningSpeed = 100;
     public bool nerdAngry = false;
     UnityEngine.AI.NavMeshAgent agent;
       void Start () {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            playerPosition = GameObject.FindGameObjectWithTag("PlayerHitBox").transform;
            laserPosition = GameObject.FindGameObjectWithTag("LaserDot").transform;
            goal = playerPosition;
        }
       void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "LaserDot") {
            Debug.Log("NERD ANGRY!");
            nerdAngry = true;
            this.agent.speed = angryNerdSpeed;
            this.agent.angularSpeed = angryNerdTurningSpeed;
            goal = playerPosition;
        }
        else if(other.gameObject.tag == "LaserRange" && nerdAngry == false) {
            Debug.Log("Nerd Interested");
            goal = laserPosition;
        }
       }
       void Update () {
           transform.eulerAngles=new Vector3(0,0,0);
           agent.SetDestination(goal.position);
       }
}
