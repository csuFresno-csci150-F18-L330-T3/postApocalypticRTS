using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResearchTree : MonoBehaviour
{

    public GameObject popUp;

    private void Start()
    {

    }

    void Update()
    {
        //Press T hotkey to open/close research tree
        if (Input.GetKeyDown(KeyCode.T))
        {
            popUp.gameObject.SetActive(!popUp.gameObject.activeSelf);
        }
        //Click Research Tree button to open/close research tree
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                popUp.gameObject.SetActive(!popUp.gameObject.activeSelf);
        }
    }

}



