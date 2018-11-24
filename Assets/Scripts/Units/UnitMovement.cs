// Prefab specific script

using UnityEngine;
using UnityEngine.EventSystems;

public class UnitMovement : MonoBehaviour
{
    public bool isSelected = false;

// Jace code block
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
//=======
  //  private float speed = 5f;
   // private Vector3 target;

   // private PlayerUnitControl pucScript = null;

  //  void Start()
   // {
   //     GameObject PlayerUnitControl = GameObject.Find("PlayerUnitControl");
    //    pucScript = PlayerUnitControl.GetComponent<PlayerUnitControl>();


   // target = transform.position;
  //  }
//>>>>>>> code from other branch
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
//<<<<<<< jace code block
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
//=======
            // Continue if unit movement mode is enabled in pucScript
 //           if (pucScript.isMovementEnabled)
 //           {
                // Check if unit is marked as selected via color
  //              Color curColor = GetComponent<SpriteRenderer>().material.color;
  //              if (curColor == Color.black)
 //               {
                    // Unit is selected, move it
 //                   if (!EventSystem.current.IsPointerOverGameObject())
//                    {
//target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//target.z = transform.position.z;
//                    }
                    
//                }
//            }
//}

 //       transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
//>>>>>>> other branch
    }
}

