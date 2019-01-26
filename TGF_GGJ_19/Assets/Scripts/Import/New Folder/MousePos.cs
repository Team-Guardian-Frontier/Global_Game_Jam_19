using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is for the mouse position and getting the sprite (rectangle) to look at the cursor
 * 
 * Input Values:
 * Player 1 - "AimX", "AimY"
 * Player 2 - "P2AimX", "P2AimY"
 */

public class MousePos : MonoBehaviour {
    // Sprite Stuff
    public Sprite N, NE, E, SE, S, SW, W, NW;
    public Camera mainCam;
    [SerializeField]
    private float RAngle;

    private Vector2 mousePos;
    private Vector2 transformPos;

    // Update is called once per frame
    void Update()
    {
        // Camera Rig Movement Control
        mousePos = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition);
        transformPos = this.transform.position;

        //toggle, makes it so it's not as sensitive.
        RAngle = Mathf.Atan2((mousePos.y - transformPos.y),(mousePos.x - transformPos.y)) * Mathf.Rad2Deg;


            MouseRotation();


    }
    
    //Utility methods
   

    // Changes sprite according to mouse angle
    void MouseRotation() {
        // call mouse angle
        float angle = RAngle;

        // Switch case to change sprite
        if (angle <= 22.5 && angle > -22.5) {
            // west
            this.GetComponent<SpriteRenderer>().sprite = E;
        } else if (angle <= 67.5 && angle > 22.5) {
            // Northwest
            this.GetComponent<SpriteRenderer>().sprite = NE;
        } else if (angle <= 112.5 && angle > 67.5) {
            // North
            this.GetComponent<SpriteRenderer>().sprite = N;
        } else if (angle <= 157.5 && angle > 112.5) {
            // Northeast
            this.GetComponent<SpriteRenderer>().sprite = NW;
        }
          // negative
          else if (angle <= -22.5 && angle > -67.5) {
            // Southwest
            this.GetComponent<SpriteRenderer>().sprite = SE;
        } else if (angle <= -67.5 && angle > -112.5) {
            // South
            this.GetComponent<SpriteRenderer>().sprite = S;
        } else if (angle <= -112.5 && angle > -157.5) {
            // Southeast
            this.GetComponent<SpriteRenderer>().sprite = SW;
        } else if (angle <= -157.5 || angle > 157.5) {
            // East
            this.GetComponent<SpriteRenderer>().sprite = W;
        }
    }
}
