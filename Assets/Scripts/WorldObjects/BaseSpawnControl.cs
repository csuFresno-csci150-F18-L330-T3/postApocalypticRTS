using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawnControl : MonoBehaviour {
    private static BaseSpawnControl baseSpawnControl;
    
    public LayerMask m_LayerMask;
    public static BaseSpawnControl Instance()
    {
        baseSpawnControl = FindObjectOfType(typeof(BaseSpawnControl)) as BaseSpawnControl;
        return baseSpawnControl;
    }

    public GameObject FindClosestBase()
    {
        GameObject[] pbase;
        pbase = GameObject.FindGameObjectsWithTag("PlayerBase");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        if (pbase == null)
        {
            //lose condition here.
        }
        else
        {
            foreach (GameObject go in pbase)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
        }
        return closest; //returns the closests object
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        FindClosestBase();
	}
}
