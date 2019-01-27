using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //launch with details. and collision
    //Wish I knew object pooling
    public float speed;
    public float angle;
    public int CustomDamage;

    private Vector2 Vector;
    private Rigidbody2D myBody;
    private SpriteRenderer myRender;
    private Collider2D myCollider;

    // Start isn't called when initializing/cloning. cuz ok i guess.
    void Awake()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myRender = this.GetComponent<SpriteRenderer>();
        myCollider = this.GetComponent<Collider2D>();


        myCollider.isTrigger = true;
    }

    //setters
    public void setSpeedAngle(float inSpeed, float inAngle)
    {
        speed = inSpeed;
        angle = inAngle;
    }

    public void setSprite(Sprite SpriteCranberry)
    {
 
        myRender.sprite = SpriteCranberry;

        /*if (ind < SpriteBank.Length && ind >=0)
        {
            myRender.sprite = SpriteBank[ind];
        }
        else
            myRender.sprite = SpriteBank[0];

        Dunno why a spritebank doesn't work. */
    }


    public void setCustomDamage(int inCust)
    {
        CustomDamage = inCust;
    }

    void CalculateVector()
    {
        float xComp = speed * Mathf.Cos(angle);
        float yComp = speed * Mathf.Sin(angle);

        Vector = new Vector2(xComp, yComp);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateVector();
        myBody.velocity = Vector;
        
    }

    //damage on collision
    //need trigger to avoid physics
    private void OnTriggerEnter2D(Collider2D collision)
{

        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<StatsManager>().TakeDamage();


            Destroy(gameObject);
        }

        //difficult to get a player interaction.
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //delete on exit.
}
