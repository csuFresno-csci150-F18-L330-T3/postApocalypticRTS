using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBlueprint : MonoBehaviour {
    public int numberOfItemsToBeCollected = 1;
    int numberOfItemsCollected = 0;
    public GameObject UnitPrefab;
    GameObject UnitPrefabClone;
    
    void SpawnUnit()
    {
        UnitPrefabClone = Instantiate(UnitPrefab, transform.position, Quaternion.identity) as GameObject;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var hit = collision.gameObject;
        if (hit.CompareTag("BluePrint"))
        {
            numberOfItemsCollected++;
            Destroy(hit);
            if (numberOfItemsCollected >= numberOfItemsToBeCollected)
            {
                numberOfItemsCollected = numberOfItemsCollected - numberOfItemsToBeCollected;
                SpawnUnit();
            }
        }
    }
    
}
