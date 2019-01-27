using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dillon Z - TGF
//Classes for damage as the platformer, and damage instances.

public class DamageClassesPlat : MonoBehaviour
{
    //controls, Z to damage, X to switch. visuals are gonna be killer.
    //don't let yourself burnout!
    public PlayerController myController;
    public StatsManager myStats;

    public Collider2D myCollider;

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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentMode == Mode.Melee)
                MeleeAttack();
        }

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
        Debug.Log("Melee Call");

        if (myController.lastDirection == PlayerController.LD.right)
            DirectAttack = Vector2.right;
        else
            DirectAttack = Vector2.left;

        int result = myCollider.Cast(DirectAttack, FilterTriggers, CastResults, AttackDist, false);

        if (result > 0)
        {
            Debug.Log("Register Hit");
            //Register hit
            if (CastResults[0].collider.CompareTag("Enemy"))
            {
                StatsManager enemyStand = CastResults[0].collider.GetComponent<StatsManager>();
                enemyStand.TakeDamage();
                Debug.Log("Sent Damage");
            }
        }
    }
}
