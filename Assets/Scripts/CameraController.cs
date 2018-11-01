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

    void Update()
    {

        Vector3 pos = transform.position;
        // WASD camera method
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
			Vector3Int posInt = Vector3Int.RoundToInt(pos);
			worldTileMap.SetTile(posInt, redSquare);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
			Vector3Int posInt = Vector3Int.RoundToInt(pos);
			worldTileMap.SetTile(posInt, redSquare);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
			Vector3Int posInt = Vector3Int.RoundToInt(pos);
			worldTileMap.SetTile(posInt, redSquare);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
			Vector3Int posInt = Vector3Int.RoundToInt(pos);
			worldTileMap.SetTile(posInt, redSquare);
        }
        //Scroll method
        scroll = Input.GetAxis("Mouse ScrollWheel");
        float zoom = mainCam.orthographicSize + (-scroll * scrollSpeed);
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        mainCam.orthographicSize = zoom;

        transform.position = pos;
    }
}
