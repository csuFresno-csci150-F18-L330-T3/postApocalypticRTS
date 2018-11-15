using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitSpawner : MonoBehaviour
{
    public GameObject enemyUnitPrefab;
    GameObject enemyUnitPrefabClone;
    Vector2 whereToSpawn;
    public float spawnRate = 10.0f;// 2 secs change if you want lower or high respawn rate
    float nextSpawn = 0.0f;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            whereToSpawn = new Vector2(5, 3);
            Instantiate(enemyUnitPrefab, whereToSpawn, Quaternion.identity);
        }
    }
}
