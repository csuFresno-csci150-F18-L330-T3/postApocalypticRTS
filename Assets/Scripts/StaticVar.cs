using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StaticVar : MonoBehaviour {

	public static Vector3Int currentCell;

	// Use this for initialization
	void Start () {
		currentCell = new Vector3Int(10, 0, 0);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
