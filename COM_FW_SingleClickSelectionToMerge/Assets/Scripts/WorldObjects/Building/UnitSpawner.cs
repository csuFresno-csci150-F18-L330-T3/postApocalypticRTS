using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour {

    public GameObject playerUnitPrefab;
    GameObject playerUnitPrefabClone;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.U)) {
            playerUnitPrefabClone = Instantiate(playerUnitPrefab, transform.position, Quaternion.identity) as GameObject;
        }
    }
}
