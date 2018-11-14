using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{ 
    public float speed;
    private Transform unit;

	void Start ()
    {
        //Set unit as gameobject to chase with the Player tag
        unit = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	void Update ()
    {
        transform.position = Vector2.MoveTowards(transform.position, unit.position, speed * Time.deltaTime);
	}
}
