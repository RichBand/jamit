using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nerd : MonoBehaviour {

	 public Transform goal;
     UnityEngine.AI.NavMeshAgent agent;
       void Start () {
          agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
          agent.destination = goal.position; 
       }
       void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        if (other.gameObject.tag == "LaserRange") {
            this.agent.speed = this.agent.speed * 3;
        }
       }
       void Update () {
           transform.eulerAngles=new Vector3(0,0,0);
           agent.SetDestination(goal.position);
       }
}
