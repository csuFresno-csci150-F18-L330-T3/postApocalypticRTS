using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PaintLeft : MonoBehaviour {
	
	public Tile redSquare;				
    public Tilemap worldTileMap;		
	

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    }
	
	public void paint(){
		StaticVar.currentCell.x -= 1;
		worldTileMap.SetTile(StaticVar.currentCell, redSquare);
	}
}
