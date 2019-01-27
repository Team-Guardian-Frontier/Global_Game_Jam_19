using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//import ui
using UnityEngine.UI;

//LastEdit- DPZ - TGF GGJ 2019s
//tracks health
public class StatsManager : MonoBehaviour {
    //temp header: this controls the player's stats like health and food groups.


    //*public Text playerText;
    //*public Text winText;


    //Public values available to set
    public int health; //health
    public int damage; //damage
    public int healing; //healing
    public int myDamage; //damage you deal to others. Probably a later implementation. (invisible damage later on.
    //pass
    public SceneStats sceneManager;

    //set during play, counters
    private int totalH;


    void Start () {


        //reset counters

        //this is to set total health.
        totalH = health;
        Display();
        //*winText.text = "";

    }

    void Update () {

        //Display();
        HealthCalc();

	}


    //get methods
    public void TakeDamage()
    {
        //adds damage, applies food group method.
        health -= damage;

        Debug.Log("Ow, I got hit!");
        
    }
    
    public void TakeDamage(int cdamage)
    {
        //adds custom damage
        health -= cdamage;
    }

    private void Display()
    {
        //don't forget the size of the text object!
        //*playerText.text = this.gameObject.name + ": " + health + "/" + totalH;

       

    }

    void HealthCalc()
    {         //death
        if (health <= 0)
        {
            Loss();
        }
    }

    public void Loss()
    {
        Debug.Log("Is this...?");
        //*winText.text = "Game Over! You are Winner!";
        sceneManager.Dying(this.tag);
        Destroy(gameObject);
    }
}
