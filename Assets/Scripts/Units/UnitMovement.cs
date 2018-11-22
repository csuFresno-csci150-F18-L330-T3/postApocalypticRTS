using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UnitMovement : MonoBehaviour
{

    private float speed = 5f;
    private Vector3 target;

    private PlayerUnitControl pucScript = null;

    void Start()
    {
        GameObject PlayerUnitControl = GameObject.Find("PlayerUnitControl");
        pucScript = PlayerUnitControl.GetComponent<PlayerUnitControl>();

        target = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (pucScript.isMovementEnabled)
            {
                Color curColor = GetComponent<SpriteRenderer>().material.color;
                if (curColor == Color.black)
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        target.z = transform.position.z;
                    }
                    
                }
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);


    }
}