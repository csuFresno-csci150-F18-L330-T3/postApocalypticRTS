using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldMapButton : MonoBehaviour
{

    public GameObject popUp;

    private void Start()
    {

    }

    void Update()
    {
        //Press M hotkey to open/close world map
        if (Input.GetKeyDown(KeyCode.M))
        {
            popUp.gameObject.SetActive(!popUp.gameObject.activeSelf);
        }
        //Click World Map button to open/close world map 
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            popUp.gameObject.SetActive(!popUp.gameObject.activeSelf);
        }
    }

}



