using UnityEngine;
using System.Collections;

public class EnemyBillboard : MonoBehaviour
{

    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}