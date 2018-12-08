using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlueprintSpawner : MonoBehaviour
{
    public int width = 512;
    public int height = 512;
    public float threshold = 50f;

    public int numberOfObjects = 10;
    public GameObject objectToSpawn;
    public GenerateWalls worldScript;
    public float distFromWalls = 10f;
    public float distFromEnemies = 15f;
    public float distFromBase = 50f;
    public int overflowLimit = 10000;

    void Start()
    {
        threshold = (threshold / 100);
        int i = 0;
        bool spawned = false;
        Color c = new Color(threshold, threshold, threshold);

        GameObject[] allBases = GameObject.FindGameObjectsWithTag("EnemyBaseSL");
        GameObject[] allWalls = GameObject.FindGameObjectsWithTag("Wall");
        GameObject playerBase = GameObject.FindGameObjectWithTag("PlayerBase");
        Debug.Log(allBases.Length);
        Debug.Log(allWalls.Length);

        while (i < numberOfObjects)
        {
            while (spawned == false && overflowLimit > 0)
            {
                int x = (int)((float)width * Random.value);
                int y = (int)((float)height * Random.value);
                if (worldScript.textureMap.GetPixel((x), (y)).b <= c.b) //compares to threshold
                {
                    bool isDistant = true;
                    Vector3 pos = new Vector3((x) - width / 2f + .5f, (y) - height / 2f + .5f, 0f);
                    foreach (GameObject enemyBase in allBases)
                    {
                        if (Vector3.Distance(pos, enemyBase.transform.position) < distFromEnemies)
                        {
                            isDistant = false;
                            break;
                        }
                    }
                    foreach (GameObject wall in allWalls)
                    {
                        if (Vector3.Distance(pos, wall.transform.position) < distFromWalls)
                        {
                            isDistant = false;
                            break;
                        }
                    }
                    if (Vector3.Distance(pos, playerBase.transform.position) < distFromBase)
                        isDistant = false;
                    if (isDistant)
                    {
                        Instantiate(objectToSpawn, pos, Quaternion.identity, transform);
                        spawned = true;
                        allBases = GameObject.FindGameObjectsWithTag("EnemyBaseSL");
                    }
                    overflowLimit--;
                }
            }
            spawned = false;
            i++;
        }
        Debug.Log(allBases.Length);
        Debug.Log(allWalls.Length);
    }
}
