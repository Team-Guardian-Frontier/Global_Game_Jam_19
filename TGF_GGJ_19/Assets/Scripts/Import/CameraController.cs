using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Author: Irvin Naylor
Last Change: Dillon Z - Just raw import to GGJ 2019
Script summary:
list of fields:
    - thePlayer: gets the playercontroller script
    - lastPlayerPosition: Stores the player's position
    - distanceToMove: 
(Any extra notes):
*/


public class CameraController : MonoBehaviour {

    public PlayerController thePlayer;

    private Vector3 lastPlayerPosition;
    private float distanceToMove;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();

        //assigns an inital value to start off of

        lastPlayerPosition = thePlayer.transform.position;

    }
	
	// Update is called once per frame
	void Update () {

        //only dealing with x-axis because moving left. This line will give the camera an amount to move.

        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

        //transform position is equal to a new vector 3 that only changes the x coordinate

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        // finds the player's x,y, and z coordinates 

        lastPlayerPosition = thePlayer.transform.position;

	}
}
