// Needed => Method to prevent overwriting exisitng worldMap units; Method to 
// prevent adding units when clicking on UI elements

using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class WorldMap : MonoBehaviour{
	
	// Objs to link sprites via Unity GUI
	public Tile attackerImg;
	public Tile defenderImg;
	public Tile wallImg;
	public Tile groundImg;
	
	// Obj to link worldMap via UnitY GUI
	public Tilemap worldMapFront;
	
	// Objs to access GUI buttons via Unity GUI
	public Button btn_usAttacker, btn_usDefender, btn_usWall;
	
	// Constants to define dimesnsions of worldMap
	public const int WORLD_X_MIN = -100;
	public const int WORLD_X_MAX = 100;
	public const int WORLD_Y_MIN = -100;
	public const int WORLD_Y_MAX = 100;
	
	// Enum of all possible gameUnitTypes
	public enum UnitType {Ground, Attacker, Defender, Wall};
	public UnitType curType = UnitType.Attacker;
	
	
	void Start(){
		// Configure OnClickListeners for used GUI buttons
		btn_usAttacker.onClick.AddListener(OnClick_usAttacker);
        btn_usDefender.onClick.AddListener(OnClick_usDefender);
        btn_usWall.onClick.AddListener(OnClick_usWall);
		
		// Preset unitSelector btn colors to showcase Attacker as selected
		btn_usAttacker.GetComponent<Image>().color = Color.green;
		btn_usDefender.GetComponent<Image>().color = Color.red;
		btn_usWall.GetComponent<Image>().color = Color.red;
		
		// Init worldMap with ground sprite
		for(int tempX = WORLD_X_MIN; tempX < WORLD_X_MAX; tempX++){
			for(int tempY = WORLD_Y_MIN; tempY < WORLD_Y_MAX; tempY++){
				addUnit(new Vector3Int(tempX, tempY, 0), UnitType.Ground);
			}
		}
	}
	
	void Update(){
		// mouseLButton pressed, add whatever unit is selected via buttons
		if(Input.GetMouseButtonDown(0)){
			addUnit(getWorldCursorPos(), curType);
		}
	}
	

	// OnClickListener for UnitSelect-Attacker btn
	void OnClick_usAttacker(){
		curType = UnitType.Attacker;
		btn_usAttacker.GetComponent<Image>().color = Color.green;
		btn_usDefender.GetComponent<Image>().color = Color.red;
		btn_usWall.GetComponent<Image>().color = Color.red;
	}
	
	// OnClickListener for UnitSelect-Defender btn
	void OnClick_usDefender(){
		curType = UnitType.Defender;
		btn_usAttacker.GetComponent<Image>().color = Color.red;
		btn_usDefender.GetComponent<Image>().color = Color.green;
		btn_usWall.GetComponent<Image>().color = Color.red;
	}
	
	// OnClickListener for UnitSelect-Wall btn
	void OnClick_usWall(){
		curType = UnitType.Wall;
		btn_usAttacker.GetComponent<Image>().color = Color.red;
		btn_usDefender.GetComponent<Image>().color = Color.red;
		btn_usWall.GetComponent<Image>().color = Color.green;
	}
	
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
			case UnitType.Attacker:
				worldMapFront.SetTile(unitPos, attackerImg);
				break;
			case UnitType.Defender:
				worldMapFront.SetTile(unitPos, defenderImg);
				break;
			case UnitType.Wall:
				worldMapFront.SetTile(unitPos, wallImg);
				break;
			case UnitType.Ground:
				worldMapFront.SetTile(unitPos, groundImg);
				break;
			default:
				break;
		}
	}
	
	// Get curCursorPos as a Vec3Int of worldCoords
	public Vector3Int getWorldCursorPos(){
		Vector3 mPosPixels = Input.mousePosition;
		Vector3 mPosWorldF = Camera.main.ScreenToWorldPoint(mPosPixels);
		Vector3Int mPosWorldI = Vector3Int.FloorToInt(mPosWorldF);
		return mPosWorldI;
	}
}
