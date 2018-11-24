// General script

using UnityEngine;

public class PlayerUnitControl : MonoBehaviour
{

    // Player unit control mode flags. Toggle to enable code for specific modes.
    public bool isMovementEnabled = false;      // Enables unit movement, accessed by UnitMovement
    private bool isUSEnabled = false;           // Enables unit selection


    void Start() { }


    void Update()
    {
        // Unit selection mode button
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Toggle current state of "Unit Selection Mode"
            isUSEnabled = !isUSEnabled;
            Debug.Log("[Unit selection mode state] = " + isUSEnabled);

            // Disable all other player control modes
            isMovementEnabled = false;
            Debug.Log("[Unit movement mode state] = " + isMovementEnabled);
        }
        
        // Unit movement mode button
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Toggle current state of "Unit Movement Mode"
            isMovementEnabled = !isMovementEnabled;
            Debug.Log("[Unit movement mode state] = " + isMovementEnabled);

            // Disable all other player control modes
            isUSEnabled = false;
            Debug.Log("[Unit selection mode state] = " + isUSEnabled);
        }

        // Mode-dependent actions based on lButtonClick of mouse
        else if (Input.GetMouseButtonDown(0))
        {
            // Actions relative to Unit selection Mode
            if (isUSEnabled)
            {
                Debug.Log("L_Mouse click, Unit selection Mode...");
                closestPUnitSelection();    // Select/Deselect the pUnit closest to the cursor
            }
        }
    }


    // Method that selects/deselects the closest player unit to the current cursor position. Selection is 
    // accomplished by changing the sprites color. Currently black sprites represent selected units and 
    // green units represent non-selected units. Other scripts can then utilize the color to determine 
    // whether a unit is grouped or not.
    private void closestPUnitSelection()
    {
        GameObject closestPUnit = getClosestPlayerUnit();

        Color curSPUColor = closestPUnit.GetComponent<SpriteRenderer>().material.color;
        if (curSPUColor != Color.black)
        {
            Debug.Log("Unit selected...");
            closestPUnit.GetComponent<SpriteRenderer>().material.color = Color.black;
        }
        else if (curSPUColor == Color.black)
        {
            Debug.Log("Unit deselected...");
            closestPUnit.GetComponent<SpriteRenderer>().material.color = Color.white;
        }
    }


    // Helper method to generate a vectorInt containing the current position of the cursor in 
    // world coordinates that are floored to produce integer values.
    private Vector3Int getCurCursorWorldCoords()
    {
        Vector3 mPosWorldF = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mPosWorldI = Vector3Int.FloorToInt(mPosWorldF);
        Debug.Log("CurCursorPos: X = " + mPosWorldI.x + ", Y = " + mPosWorldI.y);
        return mPosWorldI;
    }


    // Helper method to return the playerUnit that's currently closest to the current mouse
    // cursor position. Could probably be more efficient.
    private GameObject getClosestPlayerUnit()
    {
        // Store the current worldCoords of the cursor
        Vector3Int mPosWorldI = getCurCursorWorldCoords();

        // Generate a list of all playerUnits currently on the map
        GameObject[] pUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");

        // Find the closet playerUnit to mouse cursor and make reference to it
        GameObject selectedPUnit = null;
        for (int i = 0; i < pUnits.Length; i++)
        {
            Vector3Int puPosI = Vector3Int.FloorToInt(pUnits[i].transform.position);
            if (mPosWorldI.x == puPosI.x && mPosWorldI.y == puPosI.y)
            {
                Debug.Log("Closest player unit selected at X = " + puPosI.x + ", Y = " + puPosI.y);
                selectedPUnit = pUnits[i];
                break;
            }
        }

        return selectedPUnit;
    }
}
