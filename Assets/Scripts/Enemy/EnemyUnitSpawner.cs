using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitSpawner : MonoBehaviour
{
    private const string V = "_Enemy_";
    public GameObject enemyUnitPrefab;
    GameObject enemyUnitPrefabClone;
    //Vector2 whereToSpawn;
    public float spawnRate = 10.0f;// 2 secs change if you want lower or high respawn rate
    float nextSpawn = 0.0f;
    public StatsTracker statsTracker;
    int en = 0;

    
    // Use this for initialization
    void Start()
    {
        statsTracker = StatsTracker.Instance();
        statsTracker.Basenumber++;
        gameObject.name = "EnemyBase_" + statsTracker.Basenumber;
        statsTracker.RegBase(gameObject);
    }

    // Update is called once per frame
    void Update()
    {   if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            //whereToSpawn = new Vector2(5, 3);
            en++;
            enemyUnitPrefabClone = Instantiate(enemyUnitPrefab, transform.position, Quaternion.identity) as GameObject;
            enemyUnitPrefabClone.name = gameObject.name + V + en.ToString();
        }
    }
}
