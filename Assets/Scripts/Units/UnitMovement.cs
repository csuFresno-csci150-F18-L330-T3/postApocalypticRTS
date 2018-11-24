// Prefab specific script

using UnityEngine;
using UnityEngine.EventSystems;

public class UnitMovement : MonoBehaviour
{
    public bool isSelected = false;

// Jace code block
    private Camera camera;
    private UnitSelectHelper inputHandler;

    public Vector2 target;

    [SerializeField] private float _speed = 5;
    private void Awake()
    {
        camera = Camera.main;
        inputHandler = camera.GetComponent<UnitSelectHelper>();
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputHandler.IsWithinSelectionBounds(gameObject))
        {
            isSelected = true;
            target = transform.position;
        }

        else if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Alpha1))
        {
            Vector3Int mPosWorldI = getCurCursorWorldCoords();
            Vector3Int puPosI = Vector3Int.FloorToInt(transform.position);

            if (mPosWorldI.x == puPosI.x && mPosWorldI.y == puPosI.y)
            {
                isSelected = true;
            }
        }

        MoveUnit();
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * _speed);

    }

    private void MoveUnit()
    {
        if (inputHandler.isSelecting)
        {
            return;
        }

        if (isSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                // stop movement as well
                // target = transform.position;
                isSelected = false;
            }
        }
    }

    // Helper method to generate a vectorInt containing the current position of the cursor in 
    // world coordinates that are floored to produce integer values.
    private Vector3Int getCurCursorWorldCoords()
    {
        Vector3 mPosWorldF = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mPosWorldI = Vector3Int.FloorToInt(mPosWorldF);
        return mPosWorldI;
    }
}

