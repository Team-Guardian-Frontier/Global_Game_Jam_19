using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingRight = true;
    public Transform grounddetection;

    //sideray
    private Vector2 rayDirect;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (movingRight)
            rayDirect = Vector2.right;
        else
            rayDirect = Vector2.left;

        RaycastHit2D groundInfo = Physics2D.Raycast(grounddetection.position, Vector2.down, distance);
        RaycastHit2D WallInfo = Physics2D.Raycast(grounddetection.position, rayDirect, distance);
       //cross shaped ray detection

        if (groundInfo.collider == false || WallInfo == true )
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

  
    }

    //PLAYER DAMAGE 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController control = collision.gameObject.GetComponent<PlayerController>();
            control.DamageController();
        }
    }
}
