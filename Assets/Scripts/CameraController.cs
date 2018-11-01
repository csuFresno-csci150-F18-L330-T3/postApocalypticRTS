using UnityEngine;
using UnityEngine.Tilemaps;

//Basic WASD and Mouse camera control

public class CameraController : MonoBehaviour
{

    public float panSpeed = 10f;
    public float panBorderThickness = 5f;

    //Scroll wheel functions
    public float scroll;
    public float scrollSpeed = 10f;
    public Camera mainCam;
    float minZoom = 1f;
    float maxZoom = 20f;
	
	public Tile redSquare;				
    public Tilemap worldTileMap;	
	
	const int WORLD_X_MIN = -50;
	const int WORLD_X_MAX = 50;
	const int WORLD_Y_MIN = -50;
	const int WORLD_Y_MAX = 50;
	
	int[,] worldMap = new int[100, 100];
	
	void Start(){
		for(int i = 0; i < 100; i++){
			for(int j = 50; j < 60; j++){
				worldMap[i, j] = 1;
			}
		}
		
		int tempPosX = WORLD_X_MIN;
		int tempPosY = WORLD_Y_MAX;
		for(int i = 0; i < 100; i++){
			for(int j = 0; j < 100; j++){
				if(worldMap[i, j] == 1){
					worldTileMap.SetTile(new Vector3Int(tempPosX, tempPosY, 0), redSquare);
				}
				tempPosX++;
			}
			tempPosY--;
		}
	}

    void Update()
    {

        Vector3 pos = transform.position;
        // WASD camera method
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
			if(pos.y < WORLD_Y_MAX){
				pos.y += panSpeed * Time.deltaTime;
				
				Vector3Int posInt = Vector3Int.RoundToInt(pos);
				//worldTileMap.SetTile(posInt, redSquare);
				Debug.Log("X: " + posInt.x + "; Y: " + posInt.y);
			}
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
			if(pos.y > WORLD_Y_MIN){
				pos.y -= panSpeed * Time.deltaTime;
				
				Vector3Int posInt = Vector3Int.RoundToInt(pos);
				//worldTileMap.SetTile(posInt, redSquare);
				Debug.Log("X: " + posInt.x + "; Y: " + posInt.y);
			}
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
			if(pos.x < WORLD_X_MAX){
				pos.x += panSpeed * Time.deltaTime;
				
				Vector3Int posInt = Vector3Int.RoundToInt(pos);
				//worldTileMap.SetTile(posInt, redSquare);
				Debug.Log("X: " + posInt.x + "; Y: " + posInt.y);
			}
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
			if(pos.x > WORLD_X_MIN){
				pos.x -= panSpeed * Time.deltaTime;
				
				Vector3Int posInt = Vector3Int.RoundToInt(pos);
				//worldTileMap.SetTile(posInt, redSquare);
				Debug.Log("X: " + posInt.x + "; Y: " + posInt.y);
			}
        }
        //Scroll method
        scroll = Input.GetAxis("Mouse ScrollWheel");
        float zoom = mainCam.orthographicSize + (-scroll * scrollSpeed);
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        mainCam.orthographicSize = zoom;

        transform.position = pos;
    }
	
	
}
