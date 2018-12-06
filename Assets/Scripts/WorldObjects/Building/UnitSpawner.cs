using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour {
    public int unitCap = 5;
    public GameObject playerUnitPrefab;
    GameObject playerUnitPrefabClone;
    public StatsTracker statsTracker;
    public BaseSpawnControl baseSpawnControl;

    private void Start()
    {
        statsTracker = StatsTracker.Instance();
        baseSpawnControl = BaseSpawnControl.Instance();
        statsTracker.RegBase(gameObject);
    }
    
    void SpawnUnit()
    {
        playerUnitPrefabClone = Instantiate(playerUnitPrefab, transform.position, Quaternion.identity) as GameObject;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.U) && statsTracker.NumberOfUnits() < unitCap * statsTracker.NumberOfBases() && baseSpawnControl.FindClosestBase().transform == transform) {
            SpawnUnit();
            Debug.Log(baseSpawnControl.FindClosestBase().transform.ToString());
        }
    }
}
