using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldMapCamera : MonoBehaviour {


    public Transform camera;


    void LateUpdate()
    {
        Vector3 newPos = camera.position;
        newPos.y = transform.position.y;
        transform.position = newPos;
    }

}





