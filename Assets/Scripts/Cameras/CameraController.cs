using UnityEngine;

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
    public Vector3 panLimit;
    public Vector3 pos;

    void Start()
    {

    }
    //Press B to return Camera to base
    public void ReturnToBase()
    {
            pos.x = -5f;
            pos.y = -5f;
    }

    void Update()
    {
       pos = transform.position;

        // WASD camera method
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        //Scroll method
        scroll = Input.GetAxis("Mouse ScrollWheel");
        float zoom = mainCam.orthographicSize + (-scroll * scrollSpeed);
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        mainCam.orthographicSize = zoom;

        //Pan Limit
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);

        //Press B to return camera to base
        if (Input.GetKeyDown(KeyCode.G))
        {
            ReturnToBase();
        }

        transform.position = pos;
    }

}
