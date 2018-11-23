using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UnitMovement : MonoBehaviour
{
    public bool isSelected = false;

    private Camera camera;
    private UnitSelectHelper inputHandler;


    public Vector2 target;

    [SerializeField] private float _speed = 5;
    private void Awake()
    {
        camera = Camera.main;
        inputHandler = camera.GetComponent<UnitSelectHelper>();
        target = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (inputHandler.IsWithinSelectionBounds(gameObject))
        {
            isSelected = true;
            target = transform.position;
        }

        MoveUnit();
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * _speed);

    }

    private void MoveUnit()
    {
        if (inputHandler.isSelecting)
        {
            return;
        }

        if (isSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                // stop movement as well
                // target = transform.position;
                isSelected = false;
            }
        }
    }
}

