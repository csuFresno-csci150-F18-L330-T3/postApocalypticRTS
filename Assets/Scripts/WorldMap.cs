using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;

public class WorldMap : MonoBehaviour{
	public Tile redSquareImg;
	public Tile greenSquareImg;
	public Tile defaultWorldImg;
	
	public Tilemap worldMapFront;
	
	public const int WORLD_X_MIN = 0;
	public const int WORLD_X_MAX = 50;
	public const int WORLD_Y_MIN = 0;
	public const int WORLD_Y_MAX = 50;
	
	public enum UnitType {RedSquare, GreenSquare};
	
	
	// Need unit type, and positon for unit
	public void addUnit(Vector3Int unitPos, UnitType unitType){
		
		// Check to see if desired location is out of bounds
		if(unitPos.x < WORLD_X_MIN || unitPos.x > WORLD_X_MAX || unitPos.y < WORLD_Y_MIN || unitPos.y > WORLD_Y_MAX){
			// Desired location out of bounds, don't add units
			Debug.Log("[WorldMap]=> Can't add unit at (" + unitPos.x + ", " + unitPos.y + "); Out of Bounds...");
			return;
		}
		
		// Add desired unit's img to visible world
		switch(unitType){
			case UnitType.RedSquare:
				worldMapFront.SetTile(unitPos, redSquareImg);
				break;
			case UnitType.GreenSquare:
				worldMapFront.SetTile(unitPos, greenSquareImg);
				break;
			default:
				break;
		}
	}
	
	// Need position of unit, will be replaced with flat land
	public void removeUnit(Vector3Int unitPos){
		worldMapFront.SetTile(unitPos, defaultWorldImg);
	}
	
	// Returns unit type at current pos
	public void getUnit(){
		
	}
	
	void Start(){
		addUnit(new Vector3Int(3, 3, 0), UnitType.RedSquare);
		addUnit(new Vector3Int(4, 3, 0), UnitType.GreenSquare);
		addUnit(new Vector3Int(51, 4, 0), UnitType.GreenSquare);
		removeUnit(new Vector3Int(4, 3, 0));
	}

	void Update(){
		
		// mouseLButton pressed
		if(Input.GetMouseButtonDown(0)){
			int mPosX = (int)Input.mousePosition.x;
			int mPosY = (int)Input.mousePosition.y;
			
			
			Vector3 mPosPixels = Input.mousePosition;
			mPosPixels.z = 0;
			Vector3Int mPosWorld = Vector3Int.FloorToInt(Camera.main.ScreenToWorldPoint(mPosPixels));
			Debug.Log(mPosWorld.x + ", " + mPosWorld.y);
				
			// Add a redSquare
			addUnit(mPosWorld, UnitType.RedSquare);
		}
	}
}
