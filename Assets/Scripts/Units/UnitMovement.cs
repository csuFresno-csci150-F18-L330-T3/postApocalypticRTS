using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UnitMovement : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {
        GameObject PlayerUnitControl = GameObject.Find("PlayerUnitControl");
        PlayerUnitControl pucScript = PlayerUnitControl.GetComponent<PlayerUnitControl>();

        transform.position = Vector3.MoveTowards(transform.position, pucScript.target, pucScript.speed * Time.deltaTime);
    }
}