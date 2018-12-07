using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectBlueprint : MonoBehaviour {
    public int numberOfItemsToBeCollected = 1;
    public StatsTracker statsTracker;
    public GameObject UnitPrefab;
    GameObject UnitPrefabClone;
    public Text countText;
    
    void SpawnUnit()
    {
        UnitPrefabClone = Instantiate(UnitPrefab, transform.position, Quaternion.identity) as GameObject;
        statsTracker.builder = true;
    }

    private void Start()
    {
        statsTracker = StatsTracker.Instance();
    }

    void SetCountText()
    {
        countText.text = "Materials: " + statsTracker.NumberOfCollectedBluePrints.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var hit = collision.gameObject;
        if (hit.CompareTag("BluePrint"))
        {
 
            if (statsTracker.builder)
            {
                if (numberOfItemsToBeCollected - 1> statsTracker.NumberOfCollectedBluePrints)
                {
                    statsTracker.NumberOfCollectedBluePrints++;
                    Destroy(hit);

                }
            }
            else
            { 
                statsTracker.NumberOfCollectedBluePrints++;
                Destroy(hit);

                if (statsTracker.NumberOfCollectedBluePrints >= numberOfItemsToBeCollected)
                {
                    statsTracker.NumberOfCollectedBluePrints = statsTracker.NumberOfCollectedBluePrints - numberOfItemsToBeCollected;
                    SpawnUnit();
                }
 
            }
        }
    }
    void Update()
    {
        SetCountText();
    }


}
