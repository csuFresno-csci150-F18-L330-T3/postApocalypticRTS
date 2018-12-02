using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBlueprint : MonoBehaviour {
    public int numberOfItemsToBeCollected = 1;
    public StatsTracker statsTracker;
    public GameObject UnitPrefab;
    GameObject UnitPrefabClone;
    
    void SpawnUnit()
    {
        UnitPrefabClone = Instantiate(UnitPrefab, transform.position, Quaternion.identity) as GameObject;
        statsTracker.builder = true;
    }

    private void Start()
    {
        statsTracker = StatsTracker.Instance();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var hit = collision.gameObject;
        if (hit.CompareTag("BluePrint"))
        {
            Debug.Log("First Check"+statsTracker.NumberOfCollectedBluePrints.ToString());
            if (statsTracker.builder)
            {
                if (numberOfItemsToBeCollected == statsTracker.NumberOfCollectedBluePrints + 1)
                {
                    
                }
            }
            else
            { 
                statsTracker.NumberOfCollectedBluePrints++;
                Destroy(hit);
                Debug.Log("Second Check" + statsTracker.NumberOfCollectedBluePrints.ToString());
                if (statsTracker.NumberOfCollectedBluePrints >= numberOfItemsToBeCollected)
                {
                    statsTracker.NumberOfCollectedBluePrints = statsTracker.NumberOfCollectedBluePrints - numberOfItemsToBeCollected;
                    SpawnUnit();
                }
                Debug.Log("Third Check" + statsTracker.NumberOfCollectedBluePrints.ToString());
            }
        }
    }
    
}
