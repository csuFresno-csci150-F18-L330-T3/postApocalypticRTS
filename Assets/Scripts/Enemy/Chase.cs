﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{ 
    public float speed = 3f;
    private Vector2 direction;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = Random.insideUnitCircle;
    }
    void Start ()
    {
        direction = Random.insideUnitCircle;
        
	}
	
	void Update ()
    {
        // check distance between unit and enemy
        range = FindClosestUnit() != null ? Vector2.Distance(transform.position, FindClosestUnit().transform.position) : minDist;

        range_b = FindClosestBase() != null ? Vector2.Distance(transform.position, FindClosestBase().transform.position) : minDist_b;

        if (range_b < minDist_b)
        {
            transform.position = Vector2.MoveTowards(transform.position, FindClosestBase().transform.position, Random.Range(speed - 1, speed + 1) * Time.deltaTime);
        }
        else if (range < minDist)
        {
           //Enemy movement based on unit position
            transform.position = Vector2.MoveTowards(transform.position, FindClosestUnit().transform.position, Random.Range(speed -1, speed +1) * Time.deltaTime);
        }
        else
        {
            //direction = Random.insideUnitCircle;
            transform.Translate(direction * Time.deltaTime * Random.Range(speed - 3, speed + 1));
        }
	}
}
