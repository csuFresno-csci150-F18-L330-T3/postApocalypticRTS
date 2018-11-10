using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class WorldMap : MonoBehaviour{
	public Tile redSquareImg;
	public Tile greenSquareImg;
	public Tile defaultWorldImg;
	
	public Tilemap worldMapFront;
	
	public Button btn_usAttacker, btn_usDefender, btn_usWall;
	
	public const int WORLD_X_MIN = 0;
	public const int WORLD_X_MAX = 50;
	public const int WORLD_Y_MIN = 0;
	public const int WORLD_Y_MAX = 50;
	
	public enum UnitType {RedSquare, GreenSquare};
	
	public UnitType curType = UnitType.RedSquare;
	
	
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
	
	// Get curCursorPos as a Vec3Int of worldCoords
	public Vector3Int getWorldCursorPos(){
		Vector3 mPosPixels = Input.mousePosition;
		Vector3 mPosWorldF = Camera.main.ScreenToWorldPoint(mPosPixels);
		Vector3Int mPosWorldI = Vector3Int.FloorToInt(mPosWorldF);
		return mPosWorldI;
	}
	
	void Start(){
		btn_usAttacker.onClick.AddListener(OnClick_usAttacker);
        btn_usDefender.onClick.AddListener(OnClick_usDefender);
        btn_usWall.onClick.AddListener(OnClick_usWall);
	}

	void OnClick_usAttacker(){
		curType = UnitType.RedSquare;
		btn_usAttacker.GetComponent<Image>().color = Color.green;
		btn_usDefender.GetComponent<Image>().color = Color.red;
		btn_usWall.GetComponent<Image>().color = Color.red;
	}
	
	void OnClick_usDefender(){
		curType = UnitType.RedSquare;
		btn_usAttacker.GetComponent<Image>().color = Color.red;
		btn_usDefender.GetComponent<Image>().color = Color.green;
		btn_usWall.GetComponent<Image>().color = Color.red;
	}
	
	void OnClick_usWall(){
		curType = UnitType.GreenSquare;
		btn_usAttacker.GetComponent<Image>().color = Color.red;
		btn_usDefender.GetComponent<Image>().color = Color.red;
		btn_usWall.GetComponent<Image>().color = Color.green;
	}
	
	void Update(){
		
		// mouseLButton pressed
		if(Input.GetMouseButtonDown(0)){
				
			// Add a redSquare
			addUnit(getWorldCursorPos(), curType);
		}
		
		// mouseRButton pressed
		if(Input.GetMouseButtonDown(1)){
				
			// Add a greenSquare
			addUnit(getWorldCursorPos(), curType);
		}
	}
}
