using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour {

    //public variables so that any player can access these
    public string objectName;
    public Texture2D buildImage;
    public int cost, hitPoints, maxHitPoints;

    //Variables accessible by subclasses
    protected Player player; // used for player
    protected string[] actions = { }; // used for commands
    protected bool currentlySelected = false; // used for unit selection


	// Use this for initialization
	protected virtual void Awake()
    {


    }
	
	// Update is called once per frame
	protected virtual void Update () {
		
	}

    protected virtual void OnGUI()
    {


    }

    public void setSelection(bool selected)
    {
        currentlySelected = selected;


    }

    public string[] GetActions()
    {
        return actions;

    }
    public virtual void PerformAction(string actionToPerform)
    {
    }

}
