using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsTracker : MonoBehaviour {
    public List<GameObject> enemies;
    private static StatsTracker statsTracker; // creates a var of class
    public static StatsTracker Instance() //function that returns a reference to this
    {
        statsTracker = FindObjectOfType(typeof(StatsTracker)) as StatsTracker;
        return statsTracker;
    }
    private int numberOfCollectedBluePrints = 0;
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

    
    void Start () {
        enemies = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RegEnemies(GameObject clone)
    {
        enemies.Add(clone);
    }
}
