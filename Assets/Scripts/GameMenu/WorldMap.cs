using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour
{

    public GameObject PopUp;

    public void Open()
    {
        PopUp.SetActive(true);
    }

    public void Close()
    {
        PopUp.SetActive(false);
    }
}