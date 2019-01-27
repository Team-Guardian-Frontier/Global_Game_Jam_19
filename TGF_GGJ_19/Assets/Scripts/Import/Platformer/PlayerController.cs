using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Irvin Naylor
Last Change: Dillon - adapted for a GGJ 2019
Script summary
    - Script starts by using Player's Rigidbody component to continuously move forward
    - If the jump key is held down, the player jumps.
list of fields
    - moveSpeed: movement speed forward
    - jumpForce: Upward jump force (how high can they jump?)
    - maxSpeed: Speed Cap for player
    - accel: a proportionate value for how quickly the player accelerates
    - decelDam: the speed reduced when player gets hit
    -iTime: time the player is invincible

    - grounded: is the player on the ground?
    - whatIsGround: determines the layer the ground is on

    - myCollider: gets the Collider2d component from the player
    - myAnimator: gets the animator component for the player
Notes:
raycast not implemented yet, maybe later.
Keep Collision Detection Continuous for no bounce.
*/


public class PlayerController : MonoBehaviour {

    public Color flash;
    private Color mainColor = new Color(255,255,255);

    //movement values
    public float moveSpeed;
    public float jumpForce;
    private float direction;

    //I frames
    public float iTime = 3;
    private bool invincible;

    public Sprite Stand;
    public Sprite Duck;

    //physics and drawing
    private Rigidbody2D RigidBody_A;
    private Collider2D myCollider;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private Animator myAnimator;

    //ground collision
    public bool grounded;
    public LayerMask whatIsGround;


    private float totalDamage;

    //boxcollider height?
    private float Boxheight;

    public float jumpTime;
    public float jumpTimeCounter;
    public bool stoppedJumping;

    private int flashC;
    public int flashAmount = 10;

    //lastDirection
    public enum LD
    {
        left,
        right,
    }
    public LD lastDirection;

    private StatsManager myStats;
    

    void Start () {
        RigidBody_A = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        boxCollider = GetComponent<BoxCollider2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = mainColor;

        myAnimator = GetComponent<Animator>();

        myStats = this.GetComponent<StatsManager>();


        invincible = false;

        jumpTimeCounter = jumpTime;
       
        //boxcollider height
        Boxheight = 1.330018f;

        lastDirection = LD.right;
    }

    // Update is called once per frame
    void Update()
    {

        //returns true or false: is the player's collider touching another collider on the specified layer (aka the ground)?

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        #region Movement code
        //can try to do if both are pressed.
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -moveSpeed;
            lastDirection = LD.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = moveSpeed;
            lastDirection = LD.right;
        }
        else
            direction = 0;

        RigidBody_A.velocity = new Vector2(direction, RigidBody_A.velocity.y);

        #endregion


        #region JUMP CODE

        //reset jump time on the ground
        if (grounded) // is grounded true?
        {
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Time.timeScale == 0)
            {

            }

            else
            { 
                if (grounded) // is grounded true?
                {
                    RigidBody_A.velocity = new Vector2(RigidBody_A.velocity.x, jumpForce);
                    stoppedJumping = false;
                }
            }
        }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                RigidBody_A.velocity = new Vector2(RigidBody_A.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            //stop jumping and set your counter to zero.  The timer will reset once we touch the ground again in the update function.
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
        #endregion

        #region DUCKCODE 
        if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow) && grounded))
        {
            if (Time.timeScale == 0)
            {

            }

            else
            {
                spriteRenderer.sprite = Duck;
                boxCollider.size = new Vector2(0.7036116f, Boxheight/2);
                boxCollider.offset = new Vector2(0, -.1f);
            }

        } 
        else
        {
            if (Time.timeScale == 0)
            {

            }
            
            else
            {
                spriteRenderer.sprite = Stand;
                boxCollider.size = new Vector2(0.7036116f, 1.330018f);
                boxCollider.offset = new Vector2(0, 0);
            }

        }
        #endregion

        #region invincibility code
        if (invincible) 
        {
            
        }
        else 
        {

        }
        #endregion

        myAnimator.SetFloat("Speed", RigidBody_A.velocity.x);
        myAnimator.SetBool("Grounded", grounded);


    }

    //Damage called from other objects
    public void DamageController()
    {

        //SIZEABLE LAG FROM COLLISION
        if (!invincible)
        {
            //Ignore collisions between player and enemy
            Physics2D.IgnoreLayerCollision(9, 10, true);
            myStats.TakeDamage();
            Invoke("ResetInvulnerability", iTime);

            Debug.Log("dam" + totalDamage);

        }
        //else no damage.

    }

    void ResetInvulnerability()
    {
        invincible = false;
        //Ignore collisions between player and enemy
        Physics2D.IgnoreLayerCollision(9, 10, false);

    }

    //dunno why this is late
    private void LateUpdate()
    {
        //makes object flash when invincible
        if (invincible)
        {
            if (flashC < flashAmount) {
                spriteRenderer.color = flash;

            } else {
                spriteRenderer.color = mainColor;
            }

            if (flashC > flashAmount * 2) flashC = 0;
            flashC++;
        } else {
            spriteRenderer.color = mainColor;
        }
       
    }


}
