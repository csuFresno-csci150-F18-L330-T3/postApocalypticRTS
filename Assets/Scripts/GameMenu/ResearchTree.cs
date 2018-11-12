using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    }

    public void Open()
    {
        //Click Research Tree button to open/close world map 
        if (popUp != null)
        {
            bool isActive = popUp.activeSelf;
            popUp.SetActive(!isActive);
        }
    }
}



