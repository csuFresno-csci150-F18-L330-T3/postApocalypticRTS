using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UserInput : MonoBehaviour {

    private Player player;

    // Use this for initialization
    void Start () {
        player = transform.root.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player.human) { }
	}
}
