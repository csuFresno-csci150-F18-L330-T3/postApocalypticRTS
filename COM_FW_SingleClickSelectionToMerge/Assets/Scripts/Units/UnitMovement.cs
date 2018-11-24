// Prefab specific script

using UnityEngine;
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
            // Continue if unit movement mode is enabled in pucScript
            if (pucScript.isMovementEnabled)
            {
                // Check if unit is marked as selected via color
                Color curColor = GetComponent<SpriteRenderer>().material.color;
                if (curColor == Color.black)
                {
                    // Unit is selected, move it
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