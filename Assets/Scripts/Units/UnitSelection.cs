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

        else if(Input.GetMouseButtonDown(0))
        {
            if(isUSEnabled)
            {
                // Get curCursorPos as a Vec3Int of worldCoords
                Vector3 mPosPixels = Input.mousePosition;
                Vector3 mPosWorldF = Camera.main.ScreenToWorldPoint(mPosPixels);
                Vector3Int mPosWorldI = Vector3Int.FloorToInt(mPosWorldF);

                Debug.Log("Mouse L_Button click at x = " + mPosWorldI.x + ", y = " + mPosWorldI.y);

                GameObject[] pUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");

                for(int i = 0; i < pUnits.Length; i++)
                {
                    Vector3Int puPosI = Vector3Int.FloorToInt(pUnits[i].transform.position);
                    if(mPosWorldI.x == puPosI.x && mPosWorldI.y == puPosI.y)
                    {
                        Debug.Log("Closet unit found at x = " + puPosI.x + ", y = " + puPosI.y);
                        break;
                    }
                }
            }
        }
    }
}
