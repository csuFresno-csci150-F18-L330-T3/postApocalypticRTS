using UnityEngine;
using UnityEngine.AI;


public class Controller : MonoBehaviour {

    public Camera cam;
    
    public NavMeshAgent agent;

    // Update is called once per frame
    private void Start()
    {
        cam = Camera.main;
    }
    void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
               
                agent.SetDestination(hit.point);
            }
        }
	}
}
