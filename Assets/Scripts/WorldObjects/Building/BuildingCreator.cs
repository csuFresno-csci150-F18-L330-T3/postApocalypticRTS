using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreator : MonoBehaviour {

    public GameObject buildingPrefab;
    GameObject buildingPrefabClone;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B)) {
            buildingPrefabClone = Instantiate(buildingPrefab, transform.position, Quaternion.identity) as GameObject;
        }
    }
}
