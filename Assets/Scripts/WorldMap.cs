using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldMap : MonoBehaviour{
	public Tilemap worldTileMap;
	
	public Tile redSquareImg;
	public Tile greenSquareImg;
	public Tile defaultWorldImg;
	
	public enum UnitType {RedSquare, GreenSquare};
	
	// Need unit type, and positon for unit
	public void addUnit(Vector3Int unitPos, UnitType unitType){
		switch(unitType){
			case UnitType.RedSquare:
				worldTileMap.SetTile(unitPos, redSquareImg);
				break;
			case UnitType.GreenSquare:
				worldTileMap.SetTile(unitPos, greenSquareImg);
				break;
			default:
				break;
		}
	}
	
	// Need position of unit, will be replaced with flat land
	public void removeUnit(Vector3Int unitPos){
		worldTileMap.SetTile(unitPos, defaultWorldImg);
	}
	
	// Returns unit type at current pos
	public void getUnit(){
		
	}
	
	void Start(){
		addUnit(new Vector3Int(3, 3, 0), UnitType.RedSquare);
		addUnit(new Vector3Int(4, 3, 0), UnitType.GreenSquare);
		removeUnit(new Vector3Int(4, 3, 0));
	}

	void Update(){
	}
}
