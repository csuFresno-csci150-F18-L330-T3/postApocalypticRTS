using UnityEngine;
using System.Collections;

public class PlayerCounter : MonoBehaviour
{
    public int totPUnits = 0;

    void Start() { }

    void Update()
    {
        GameObject[] pUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");

        if (totPUnits < pUnits.Length)
        {
            totPUnits = pUnits.Length;
            Debug.Log("Total Player Units = " + totPUnits);
        }
    }
}