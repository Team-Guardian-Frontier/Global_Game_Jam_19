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
    //raycast collision
    const float skinWidth = .015f;
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;
    float horizontalRaySpacing;
    float verticalRaySpacing;
    RaycastOrigins raycastOrigins;

    private float totalDamage;

    //boxcollider height?
    private float Boxheight;

    public float jumpTime;
    public float jumpTimeCounter;
    public bool stoppedJumping;

    private int flashC;
    public int flashAmount = 10;

    void Start () {
        RigidBody_A = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        boxCollider = GetComponent<BoxCollider2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = mainColor;

        myAnimator = GetComponent<Animator>();



        invincible = false;

        jumpTimeCounter = jumpTime;
       
        //boxcollider height
        Boxheight = 1.330018f;


    }

    // Update is called once per frame
    void Update()
    {

        //returns true or false: is the player's collider touching another collider on the specified layer (aka the ground)?

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        #region Movement code
        //can try to do if both are pressed.
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            direction = -moveSpeed;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            direction = moveSpeed;
        else
            direction = 0;

        RigidBody_A.velocity = new Vector2(direction, RigidBody_A.velocity.y);

        #endregion

        #region Collision Code (Raycast)
        //Tutorial from Sebastian Lague
        UpdateRaycastOrigins();
        CalculateRaySpacing();

        for (int i = 0; i < verticalRayCount; i++)
        {
            Debug.DrawRay(raycastOrigins.bottomLeft + Vector2.right * verticalRaySpacing * i, Vector2.up * -2, Color.red);
        }

        #endregion

        #region JUMP CODE

        //reset jump time on the ground
        if (grounded) // is grounded true?
        {
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
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

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) && !stoppedJumping)
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
    public void Damage()
    {

        if (!invincible)
        {
            Debug.Log("Damage");

        }

    }

    //NOTE: make wins and losses occur on the player. who needs game managers?
    public void Winning()
    {
        
    }
    void Losing()
    {

    }

    void ResetInvulnerability()
    {
        invincible = false;

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

    //RAYCAST COLLISION
    //tutorial from Sebastian Lague
    void UpdateRaycastOrigins()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }


    void CalculateRaySpacing()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }

}
