using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour {

    //public variables so that any player can access these
    public string objectName;
    public Texture2D buildImage;
    public int cost, hitPoints, maxHitPoints;

    //Variables accessible by subclasses
    protected Player player;
    protected string[] actions = { };
    protected bool currentlySelected = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
