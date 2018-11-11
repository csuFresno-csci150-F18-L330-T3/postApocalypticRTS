using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour
{

    public GameObject PopUp;


    public void Open()
    {
        PopUp.gameObject.SetActive(true);
    }

    public void Close()
    {
        PopUp.gameObject.SetActive(false);
    }
}


