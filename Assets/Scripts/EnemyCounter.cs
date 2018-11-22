using UnityEngine;
using System.Collections;

public class EnemyCounter : MonoBehaviour
{
    public int totEUnits = 0;

    void Start() { }

    void Update()
    {
        GameObject[] eUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        
        if(totEUnits < eUnits.Length)
        {
            totEUnits = eUnits.Length;
            Debug.Log("Total Enemy Units = " + totEUnits);
        }
    }
}
