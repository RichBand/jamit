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
       void Update () {
           transform.eulerAngles=new Vector3(0,0,0);
           agent.SetDestination(goal.position);
       }
}
