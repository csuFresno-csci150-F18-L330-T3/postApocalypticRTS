using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{ 
    public float speed = 3f;
    
    public float minDist = 7f;
    private float range;

    public GameObject FindClosestUnit()
    {
        GameObject[] unit;
        unit = GameObject.FindGameObjectsWithTag("Player");
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
        

        if (range < minDist)
        {
            //Enemy movement based on unit position
            transform.position = Vector2.MoveTowards(transform.position, FindClosestUnit().transform.position, speed * Time.deltaTime);
        }
	}
}
