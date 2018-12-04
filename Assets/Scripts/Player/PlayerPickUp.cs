using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour {


  

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PickUps")
        //if (other.gameObject.name == "Parts")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);


        }

    }

}
