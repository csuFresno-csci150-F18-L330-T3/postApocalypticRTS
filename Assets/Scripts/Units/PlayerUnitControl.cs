using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerUnitControl : MonoBehaviour
{
    public int totPUnits = 0;

    private bool isUSEnabled = false;
    public bool isMovementEnabled = false;

    private bool isSelected = false;

    public float speed = 5f;
    public Vector3 target;

    private bool isSelecting = false;
    private Vector3 mousePosition1;
    private Rect curSelectRect;
    private bool isFirstShot = false;

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

                //Save mouse location after left click
                isSelecting = true;
                mousePosition1 = Input.mousePosition;

                //End selection after letting go of left click
          


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
        }

        else if (Input.GetMouseButtonUp(0))
        {
            if (isUSEnabled && isSelecting)
            {
                isSelecting = false;
                isFirstShot = true;
            }
        }


        if (!isSelecting && isFirstShot)
        {
            isFirstShot = false;

            Vector3 selRect_topL = new Vector3(curSelectRect.xMin, curSelectRect.yMin, 0);
            Vector3 selRect_topR = new Vector3(curSelectRect.xMax, curSelectRect.yMin, 0);
            Vector3 selRect_botL = new Vector3(curSelectRect.xMin, curSelectRect.yMax, 0);
            Vector3 selRect_botR = new Vector3(curSelectRect.xMax, curSelectRect.yMax, 0);

            Vector3Int selRect_topL_I = Vector3Int.FloorToInt(Camera.main.ScreenToWorldPoint(selRect_topL));
            Vector3Int selRect_topR_I = Vector3Int.FloorToInt(Camera.main.ScreenToWorldPoint(selRect_topR));
            Vector3Int selRect_botL_I = Vector3Int.FloorToInt(Camera.main.ScreenToWorldPoint(selRect_botL));
            Vector3Int selRect_botR_I = Vector3Int.FloorToInt(Camera.main.ScreenToWorldPoint(selRect_botR));

            GameObject[] pUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");

            for (int i = 0; i < pUnits.Length; i++)
            {
                Vector3Int puPosI = Vector3Int.FloorToInt(pUnits[i].transform.position);

                if (puPosI.x >= selRect_topL_I.x && puPosI.x <= selRect_topR_I.x)
                {
                    if (puPosI.y >= selRect_topL_I.y && puPosI.y <= selRect_botL_I.y)
                    {
                        // Unit within range, select it
                        Color curSPUColor = pUnits[i].GetComponent<SpriteRenderer>().material.color;
                        if (curSPUColor != Color.black)
                        {
                            Debug.Log("Unit selected...");
                            pUnits[i].GetComponent<SpriteRenderer>().material.color = Color.black;
                        }
                        else if (curSPUColor == Color.black)
                        {
                            Debug.Log("Unit deselected...");
                            pUnits[i].GetComponent<SpriteRenderer>().material.color = Color.white;
                        }
                    }
                }
            }
        }

    }

    void OnGUI()
    {
        if (isUSEnabled && isSelecting)
        {
            //Generate rect from mouse positions
            var rect = Utilities.GetScreenRect(mousePosition1, Input.mousePosition);
            curSelectRect = rect;
            Utilities.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            Utilities.DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }
}


public static class Utilities
{
    static Texture2D whiteTexture;
    public static Texture2D WhiteTexture
    {
        get
        {
            if (whiteTexture == null)
            {
                whiteTexture = new Texture2D(1, 1);
                whiteTexture.SetPixel(0, 0, Color.white);
                whiteTexture.Apply();
            }
            return whiteTexture;
        }
    }
    //using GUI to draw rectangle on screen
    public static void DrawScreenRect(Rect rect, Color color)
    {
        GUI.color = color;
        GUI.DrawTexture(rect, WhiteTexture);
        GUI.color = Color.white;
    }
    //rectangle borders
    public static void DrawScreenRectBorder(Rect rect, float thickness, Color color)
    {
        //Top
        Utilities.DrawScreenRect(new Rect(rect.xMin, rect.yMin, rect.width, thickness), color);
        //Left
        Utilities.DrawScreenRect(new Rect(rect.xMin, rect.yMin, thickness, rect.height), color);
        //Right
        Utilities.DrawScreenRect(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), color);
        //Bottom
        Utilities.DrawScreenRect(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), color);
    }

    public static Rect GetScreenRect(Vector3 screenPosition1, Vector3 screenPosition2)
    {
        //Set Origin
        screenPosition1.y = Screen.height - screenPosition1.y;
        screenPosition2.y = Screen.height - screenPosition2.y;
        //Corners
        var topLeft = Vector3.Min(screenPosition1, screenPosition2);
        var bottomRight = Vector3.Max(screenPosition1, screenPosition2);
        //Generate Rectangle 
        return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
    }
}
