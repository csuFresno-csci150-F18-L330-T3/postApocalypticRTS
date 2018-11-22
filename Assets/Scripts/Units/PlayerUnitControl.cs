using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerUnitControl : MonoBehaviour
{
    public int totPUnits = 0;

    private bool isUSEnabled = false;
    public bool isMovementEnabled = false;

    private bool isSelected = false;

    public float speed = 5f;
    public Vector3 target;

    void Start()
    {
        target = new Vector3(-7f, -0.3f, 0f);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
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

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!isMovementEnabled)
            {
                Debug.Log("Unit movement mode enabled...");
                isMovementEnabled = true;
            }
            else
            {
                Debug.Log("Unit movement mode disabled...");
                isMovementEnabled = false;
            }
        }

        else if (Input.GetMouseButtonDown(0))
        {
            if (isUSEnabled)
            {
                // Get curCursorPos as a Vec3Int of worldCoords
                Vector3 mPosPixels = Input.mousePosition;
                Vector3 mPosWorldF = Camera.main.ScreenToWorldPoint(mPosPixels);
                Vector3Int mPosWorldI = Vector3Int.FloorToInt(mPosWorldF);

                Debug.Log("Mouse L_Button click at x = " + mPosWorldI.x + ", y = " + mPosWorldI.y);

                GameObject[] pUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
                GameObject selectedPUnit = null;

                for (int i = 0; i < pUnits.Length; i++)
                {
                    Vector3Int puPosI = Vector3Int.FloorToInt(pUnits[i].transform.position);
                    if (mPosWorldI.x == puPosI.x && mPosWorldI.y == puPosI.y)
                    {
                        Debug.Log("Selected unit at x = " + puPosI.x + ", y = " + puPosI.y);
                        selectedPUnit = pUnits[i];
                        break;
                    }
                }

                Color curSPUColor = selectedPUnit.GetComponent<SpriteRenderer>().material.color;
                if(curSPUColor != Color.black)
                {
                    Debug.Log("Unit selected...");
                    selectedPUnit.GetComponent<SpriteRenderer>().material.color = Color.black;
                }
                else if (curSPUColor == Color.black)
                {
                    Debug.Log("Unit deselected...");
                    selectedPUnit.GetComponent<SpriteRenderer>().material.color = Color.white;
                }

            }

            else if (isMovementEnabled)
            {
                
            }
        }

    }
}
