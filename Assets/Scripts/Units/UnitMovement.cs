using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UnitMovement : MonoBehaviour
{

    public float speed = 5f;
    private Vector3 target;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }
}