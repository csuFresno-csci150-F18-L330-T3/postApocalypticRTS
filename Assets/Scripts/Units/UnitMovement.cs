using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    private Vector2 target;
    private Camera camera;
    private UnitSelectHelper inputHandler;
    private bool isSelected = false;
    [SerializeField] private float _speed = 5;

    private void Awake()
    {
        camera = Camera.main;
        inputHandler = camera.GetComponent<UnitSelectHelper>();
        target = transform.position;
    }

    void Update()
    {
        // Check if unit contained within selection rectangle (Multi-Unit Selection)
        if (inputHandler.IsWithinSelectionBounds(gameObject))
        {
            isSelected = true;
            target = transform.position;
        }

        // Check if unit is to be selected by user (Single Unit Selection)
        else if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Alpha1))
        {
            Vector3Int mPosWorldI = getCurCursorWorldCoords();
            Vector3Int puPosI = Vector3Int.FloorToInt(transform.position);

            if (mPosWorldI.x == puPosI.x && mPosWorldI.y == puPosI.y)
            {
                isSelected = true;
            }
        }

        // Update unit's target position based on player's desired movement position
        MoveUnit();

        // Update unit's current positon within world
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
