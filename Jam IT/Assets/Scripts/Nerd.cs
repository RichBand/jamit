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
     GameObject laserDot;
     GameObject RightProjectorAssembly;
     GameObject LeftProjectorAssembly;
     GameObject RearProjectorAssembly;
     public int nerdSpeed;
     public int angryNerdSpeed = 5000;
     public int angryNerdTurningSpeed = 100;
     public bool nerdFollowingPlayer = true;
     public bool nerdAngry = false;
     public bool nerdInterested = false;
     public bool nerdWatchingMovie = false;
     public bool nerdWatchingMovieOnRight = false;
     public bool nerdWatchingMovieOnLeft = false;
     public bool nerdWatchingMovieOnRear = false;

     UnityEngine.AI.NavMeshAgent agent;
       void Start () {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
            laserDot = GameObject.FindGameObjectWithTag("LaserDot");
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
        }
        else if (other.gameObject.tag == "RightProjectorAssembly" && nerdAngry == false && RightProjectorAssembly.GetComponent<ProjectorController>().projectorActivated == true) {
            Debug.Log("Ooooh, movie!");
            nerdWatchingMovie = true;
            nerdWatchingMovieOnRight = true;
        }
        else if (other.gameObject.tag == "LeftProjectorAssembly" && nerdAngry == false && LeftProjectorAssembly.GetComponent<ProjectorController>().projectorActivated == true) {
            Debug.Log("Ooooh, movie!");
            nerdWatchingMovie = true;
            nerdWatchingMovieOnLeft = true;
        }
        else if (other.gameObject.tag == "RearProjectorAssembly" && nerdAngry == false && RearProjectorAssembly.GetComponent<ProjectorController>().projectorActivated == true) {
            Debug.Log("Ooooh, movie!");
            nerdWatchingMovie = true;
            nerdWatchingMovieOnRear = true;
        }
       }
       void Update () {
           //transform.eulerAngles= new Vector3(0,0,0);
           WhatToDo();
           agent.SetDestination(goal.position);
           
           
       }
       private void WhatToDo () {
            if (nerdWatchingMovie) {
                if (nerdWatchingMovieOnRight == true) {
                goal = RightProjectorPosition;
                }
                if (nerdWatchingMovieOnLeft == true) {
                goal = LeftProjectorPosition;
                }
                if (nerdWatchingMovieOnRear == true) {
                goal = RearProjectorPosition;
                }
           }
            else if (nerdInterested == true && laserDot.GetComponent<LaserDotController>().laserActivated == true) {
                goal = laserPosition;
            }
            else {
               goal = playerPosition;
           }
       }
}