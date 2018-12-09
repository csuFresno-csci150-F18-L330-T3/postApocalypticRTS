using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsTracker : MonoBehaviour {
    public List<GameObject> allBases;
    private static StatsTracker statsTracker; // creates a var of class
    public static StatsTracker Instance() //function that returns a reference to this
    {
        statsTracker = FindObjectOfType(typeof(StatsTracker)) as StatsTracker;
        return statsTracker;
    }
    private int numberOfCollectedBluePrints = 0;
    private int basenumber = 0;
    public bool builder = false;

    public int NumberOfCollectedBluePrints 
    {
        get
        {
            return numberOfCollectedBluePrints;
        }

        set
        {
            numberOfCollectedBluePrints = value;
        }
    }

    public int Basenumber
    {
        get
        {
            return basenumber;
        }

        set
        {
            basenumber = value;
        }
    }

    // Use this for initialization
    public int NumberOfBluePrints()
    {
        GameObject[] bluePrints;
        bluePrints = GameObject.FindGameObjectsWithTag("BluePrint");
        return bluePrints.Length;
    }

    public int NumberOfUnits()
    {
        GameObject[] units;
        units = GameObject.FindGameObjectsWithTag("PlayerUnit");
        return units.Length;
    }

    public int NumberOfEnemies()
    {
        GameObject[] e_units;
        e_units = GameObject.FindGameObjectsWithTag("EnemyUnit");
        return e_units.Length;
    }
    public int NumberOfBases()
    {
        GameObject[] bases;
        bases = GameObject.FindGameObjectsWithTag("PlayerBase");
        return bases.Length;
    }


    void Awake () {
        allBases = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
		if (NumberOfBases()== 0)
        {
            //lose conditions here.
            Debug.Log("GameOver");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
	}

    public void RegBase(GameObject clone)
    {
        Debug.Log("Registered " + clone.name);
        allBases.Add(clone);
    }
}
