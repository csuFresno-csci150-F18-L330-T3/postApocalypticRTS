using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{ 
    public float speed = 3f;
    private Transform unit;
    public float minDist = 10f;
    private float range;


	void Start ()
    {
        //Set unit as gameobject to chase with the Player tag
        unit = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	void Update ()
    {
        // check distance between unit and enemy
        range = Vector2.Distance(transform.position, unit.position);

        if (range < minDist)
        {
            //Enemy movement based on unit position
            transform.position = Vector2.MoveTowards(transform.position, unit.position, speed * Time.deltaTime);
        }
	}
}
