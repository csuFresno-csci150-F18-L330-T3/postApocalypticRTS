using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour {
    public int unitCap = 5;
    public GameObject playerUnitPrefab;
    GameObject playerUnitPrefabClone;

    int NumberOfBases()
    {
        GameObject[] bases;
        bases = GameObject.FindGameObjectsWithTag("PlayerBase");
        return bases.Length;
    }
    int NumberOfUnits()
    {
        GameObject[] unit;
        unit = GameObject.FindGameObjectsWithTag("PlayerUnit");
        return unit.Length;
    }

    void SpawnUnit()
    {
        playerUnitPrefabClone = Instantiate(playerUnitPrefab, transform.position, Quaternion.identity) as GameObject;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.U) && NumberOfUnits() < unitCap * NumberOfBases()) {
            SpawnUnit();
        }
    }
}
