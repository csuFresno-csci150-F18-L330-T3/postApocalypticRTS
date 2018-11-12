using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapButton : MonoBehaviour
{

    public GameObject popUp;

    void Start()
    {

    }

    void Update()
    {
        //Press M hotkey to open/close world map
        if (Input.GetKeyDown(KeyCode.M))
        {
            popUp.gameObject.SetActive(!popUp.gameObject.activeSelf);
        }
    }

    public void Open()
    {
        //Click World Map button to open/close world map 
        if (popUp != null)
        {
            bool isActive = popUp.activeSelf;
            popUp.SetActive(!isActive);
        }
    }

}

