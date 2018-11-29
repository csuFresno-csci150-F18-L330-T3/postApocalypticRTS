using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreator : MonoBehaviour {

    public GameObject buildingPrefab;
    GameObject[] buildingSpace;
    GameObject buildingPrefabClone;
    public bool useTag = false;
    public string myTag;
    
	// Use this for initialization
	void Start () {
		if (useTag == true && myTag != "")//this should place a building in a place with the indicated tag
        {
            
            buildingSpace = GameObject.FindGameObjectsWithTag(myTag);
            foreach(GameObject myBuilding in buildingSpace)
            {
                Instantiate(buildingPrefab, myBuilding.transform.position, myBuilding.transform.rotation);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B) && useTag == false) {
            buildingPrefabClone = Instantiate(buildingPrefab, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
        }
    }
}
