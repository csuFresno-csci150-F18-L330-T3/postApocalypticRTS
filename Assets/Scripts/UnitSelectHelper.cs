using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectHelper : MonoBehaviour
{
    bool isSelecting = false;
    Vector3 mousePosition1;

    void Start()
    {

    }


    void Update()
    {
        //Save mouse location after left click
        if (Input.GetMouseButtonDown(0))
        {
            isSelecting = true;
            mousePosition1 = Input.mousePosition;
        }
        //End selection after letting go of left click
        if (Input.GetMouseButtonUp(0))
        isSelecting = false;
    }

    void OnGUI()
    {
        if (isSelecting)
        {
            //Generate rect from mouse positions
            var rect = Utilities.GetScreenRect(mousePosition1, Input.mousePosition);
            Utilities.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            Utilities.DrawScreenRectBorder( rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }
}
