using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour {
    public int unitCap = 5;
    public GameObject playerUnitPrefab;
    GameObject playerUnitPrefabClone;
    public StatsTracker statsTracker;

    private void Start()
    {
        statsTracker = StatsTracker.Instance();
        statsTracker.RegBase(gameObject);
    }
    
    void SpawnUnit()
    {
        playerUnitPrefabClone = Instantiate(playerUnitPrefab, transform.position, Quaternion.identity) as GameObject;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.U) && statsTracker.NumberOfUnits() < unitCap * statsTracker.NumberOfBases()) {
            SpawnUnit();
        }
    }
}
