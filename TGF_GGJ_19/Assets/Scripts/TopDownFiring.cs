using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownFiring : MonoBehaviour
{
    private MousePos myMouse;
    private StatsManager myStats;

    //public bullet stuff
    public GameObject bullet;
    public float bulletSpeed;
    private float launchAngle;
    public Sprite BulletSprite;

    //Attack rate, in frames
    public int attackspeed;
    private int attacktimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        myMouse = this.GetComponent<MousePos>();
        myStats = this.GetComponent<StatsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //timer
        attacktimer++;

        if(attacktimer>attackspeed)
        {
            //IF YOU NEED FULL AUTO, CHANGE TO GETMOUSEBUTTON
            if(Input.GetMouseButtonDown(0))
            {
                RangeAttack();
            }
        }
    }

    void RangeAttack()
    {
        //needs radians
        launchAngle = myMouse.getAngle();

        GameObject bulletbaby = (GameObject)Instantiate(bullet, transform.position, transform.rotation, transform);
        BulletScript bulletScript = bulletbaby.GetComponent<BulletScript>();
        //set bullet properties
        bulletScript.setSpeedAngle(bulletSpeed, launchAngle);
        bulletScript.setSprite(BulletSprite);

    }
}
