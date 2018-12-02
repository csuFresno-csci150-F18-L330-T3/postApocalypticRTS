using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseLocGen : MonoBehaviour {
    public float minX= -250.0f, maxX= 250.0f, minY=-130.0f, maxY= 130.0f;
    public float numberOfBases = 10;
    public GameObject buildingContainerPrefab;
    //GameObject[] buildingContainerSpace;
    // Use this for initialization
    void Awake () {
        for (int i = 0; i < numberOfBases; i++)
        {
            Vector3 position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
            Instantiate(buildingContainerPrefab, position, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
