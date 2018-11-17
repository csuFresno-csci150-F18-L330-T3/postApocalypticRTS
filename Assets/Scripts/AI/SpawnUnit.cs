using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : MonoBehaviour {

    public Camera cam;
    public GameObject unit;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 pos = hit.point;
                pos.z = 0.001f;
                float temp = pos.y;
                for (int i = 0; i < 100; i++)
                {
                    Instantiate(unit, pos, Quaternion.identity, transform);
                    pos.y += Random.value * 1.6f;
                    if (i == 80)
                    {
                        pos.x += 1f;
                        pos.y = temp;
                    }
                    else if (i == 60)
                    {
                        pos.x += 1f;
                        pos.y = temp;
                    }
                    else if (i == 40)
                    {
                        pos.x += 1f;
                        pos.y = temp;
                    }
                    else if (i == 20)
                    {
                        pos.x += 1f;
                        pos.y = temp;
                    }
                }
            }
        }
    }
}
