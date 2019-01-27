using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dillon Z - TGF
//Classes for damage as the platformer, and damage instances.

public class DamageClassesPlat : MonoBehaviour
{
    //controls, Z to damage, X to switch. visuals are gonna be killer.
    //don't let yourself burnout!
    private PlayerController myController;
    private StatsManager myStats;

    private Collider2D myCollider;

    //public bullet stuff
    public GameObject bullet;
    public float bulletSpeed;
    private float launchAngle;
    public Sprite BulletSprite;

    private RaycastHit2D[] CastResults;
    private ContactFilter2D FilterTriggers;
    public float AttackDist;
    private Vector2 DirectAttack;

    //raycasts

    //Modes
    enum Mode
    {
        Melee,
        Mage,
    }
    private Mode currentMode = Mode.Melee;

    //Attack rate, in frames
    public int attackspeed;
    private int attacktimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        //grab on object comps
        myController = this.GetComponent<PlayerController>();
        myCollider = this.GetComponent<Collider2D>();
        myStats = this.GetComponent<StatsManager>();

        CastResults = new RaycastHit2D[1];

        //set up filter to just not interact with trigger colliders
        FilterTriggers.useTriggers = false;



    }

    // Update is called once per frame
    void Update()
    {
        //timer increment
        attacktimer++;

        //change attack speed with mode if needed.
        //attack
        if (attacktimer >= attackspeed)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (currentMode == Mode.Melee)
                    MeleeAttack();
                else
                    RangeAttack();
                attacktimer = 0;
            }
        }

        //swap
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (currentMode == Mode.Melee)
                currentMode = Mode.Mage;
            else
                currentMode = Mode.Melee;

            Debug.Log("Mode: " + currentMode);
        }
    }
    
    //Melee damage
    void MeleeAttack()
    {

        if (myController.lastDirection == PlayerController.LD.right)
            DirectAttack = Vector2.right;
        else
            DirectAttack = Vector2.left;


        int result = myCollider.Cast(DirectAttack, FilterTriggers, CastResults, AttackDist, false);

        if (result > 0)
        {
 
            //Register hit
            if (CastResults[0].collider.CompareTag("Enemy"))
            {
                StatsManager enemyStand = CastResults[0].collider.GetComponent<StatsManager>();
                enemyStand.TakeDamage();
            }
        }
    }

    void RangeAttack()
    {
        if (myController.lastDirection == PlayerController.LD.right)
            launchAngle = 0f;
        else
            launchAngle = Mathf.PI;

        GameObject bulletbaby = (GameObject) Instantiate(bullet, transform.position, transform.rotation, transform);
        BulletScript bulletScript = bulletbaby.GetComponent<BulletScript>();
        //set bullet properties
        bulletScript.setSpeedAngle(bulletSpeed, launchAngle);
        bulletScript.setSprite(BulletSprite);
       
    }
}
