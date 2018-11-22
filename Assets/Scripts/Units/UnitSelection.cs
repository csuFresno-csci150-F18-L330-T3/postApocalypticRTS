using UnityEngine;
using System.Collections;

public class UnitSelection : MonoBehaviour
{
    public int totPUnits = 0;

    private bool isUSEnabled = false;

    void Start() { }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (!isUSEnabled)
            {
                Debug.Log("Unit select mode enabled...");
                isUSEnabled = true;
            }
            else
            {
                Debug.Log("Unit select mode disabled...");
                isUSEnabled = false;
            }
        }

        /*if(Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Unit select mode enabled...");

            // Get curCursorPos as a Vec3Int of worldCoords
            Vector3 mPosPixels = Input.mousePosition;
            Vector3 mPosWorldF = Camera.main.ScreenToWorldPoint(mPosPixels);
            Vector3Int mPosWorldI = Vector3Int.FloorToInt(mPosWorldF);

        }*/
    }






}
/*
    void Update()
    {
        GameObject[] pUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");

        if (totPUnits < pUnits.Length)
        {
            totPUnits = pUnits.Length;
            Debug.Log("Total Player Units = " + totPUnits);
        }
    }


    void Update()
    {
        // mouseLButton pressed, add whatever unit is selected via buttons
        if (Input.GetMouseButtonDown(0))
        {
            addUnit(getWorldCursorPos(), curType);
        }
    }

    // Need unit type, and positon for unit
    public void addUnit(Vector3Int unitPos, UnitType unitType)
    {

        // Check to see if desired location is out of bounds
        if (unitPos.x < WORLD_X_MIN || unitPos.x > WORLD_X_MAX || unitPos.y < WORLD_Y_MIN || unitPos.y > WORLD_Y_MAX)
        {
            // Desired location out of bounds, don't add units
            Debug.Log("[WorldMap]=> Can't add unit at (" + unitPos.x + ", " + unitPos.y + "); Out of Bounds...");
            return;
        }

        // Add desired unit's img to visible world
        switch (unitType)
        {
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
    public Vector3Int getWorldCursorPos()
    {
        Vector3 mPosPixels = Input.mousePosition;
        Vector3 mPosWorldF = Camera.main.ScreenToWorldPoint(mPosPixels);
        Vector3Int mPosWorldI = Vector3Int.FloorToInt(mPosWorldF);
        return mPosWorldI;
    }
}*/
