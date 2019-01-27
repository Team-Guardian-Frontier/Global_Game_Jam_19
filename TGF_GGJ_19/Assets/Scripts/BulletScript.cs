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
    public Sprite[] SpriteBank;

    private Vector2 Vector;
    private Rigidbody2D myBody;
    private SpriteRenderer myRender;

    // Start is called before the first frame update
    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myRender = this.GetComponent<SpriteRenderer>();
    }

    public void setSpeedAngle(float inSpeed, float inAngle)
    {
        speed = inSpeed;
        angle = inAngle;
    }

    public void setSprite(int ind)
    {
        if (ind < SpriteBank.Length)
        {
            myRender.sprite = SpriteBank[ind];
        }
        else
            myRender.sprite = SpriteBank[ind];
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bullet HIt");
        //collision.othercollider refers to this obj's collider, for some godforsaken reason.
        GameObject visiting = collision.collider.gameObject;
        Debug.Log("HasObject: " + (visiting != null));
        Debug.Log("ObjTag" + visiting.tag);
        if (visiting.CompareTag("Enemy"))
        {
            visiting.GetComponent<StatsManager>().TakeDamage();
            Debug.Log("Das an enemy");
        }

        Destroy(gameObject);
    }

    //delete on exit.
}
