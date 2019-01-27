using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dying(string tag)
    {
        if (tag.Equals("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GlobalStats.Deaths += 1;
        }
        else if (tag.Equals("Enemy"))
        {
            GlobalStats.Kills += 1;
        }
        else
            Debug.Log("Wrong line to heaven, buddy.");
    }
}
