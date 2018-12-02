using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{ 
    public float speed = 3f;
    
    public float minDist = 7f;
    public float minDist_b = 5f;
    private float range, range_b;
    public GameObject FindClosestBase()
    {
        GameObject[] pbase;
        pbase = GameObject.FindGameObjectsWithTag("PlayerBase");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        if (pbase == null) {
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
    public GameObject FindClosestUnit()
    {
        GameObject[] unit;
        unit = GameObject.FindGameObjectsWithTag("PlayerUnit");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        if (unit == null) { }
        else
        {
            foreach (GameObject go in unit)
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
	void Start ()
    {
        //Set unit as gameobject to chase with the Player tag
        
	}
	
	void Update ()
    {
        
        // check distance between unit and enemy
        
        range = Vector2.Distance(transform.position, FindClosestUnit().transform.position);
        range_b = Vector2.Distance(transform.position, FindClosestBase().transform.position);

 
        if (range < minDist)
        {
            if (range_b < minDist_b)
            {
                transform.position = Vector2.MoveTowards(transform.position, FindClosestBase().transform.position, speed * Time.deltaTime);
            }
            else
            {
                //Enemy movement based on unit position
                transform.position = Vector2.MoveTowards(transform.position, FindClosestUnit().transform.position, speed * Time.deltaTime);
            }
        }
	}
}
