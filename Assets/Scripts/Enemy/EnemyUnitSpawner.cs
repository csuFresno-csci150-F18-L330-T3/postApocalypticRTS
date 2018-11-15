using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitSpawner : MonoBehaviour
{

    public GameObject enemyUnitPrefab;
    GameObject enemyUnitPrefabClone;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            enemyUnitPrefabClone = Instantiate(enemyUnitPrefab, transform.position, Quaternion.identity) as GameObject;
        }
    }
}
