
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
    protected Bounds selectionBounds;
    protected Rect playingArea= new Rect(0.0f, 0.0f, 0.0f, 0.0f);

    // Use this for initialization
    protected virtual void Awake()
    {
        

    }
    
    // Update is called once per frame
    protected virtual void Update () {
        
    }

   

    public void setSelection(bool selected)
    {
        currentlySelected = selected;
        

    }
    protected virtual void Start()
    {
        player = transform.root.GetComponentInChildren<Player>();
    }


    public string[] GetActions()
    {
        return actions;

    }
    public virtual void PerformAction(string actionToPerform)
    {
    }

  

    public void CalculateBounds()
    {
        selectionBounds = new Bounds(transform.position, Vector3.zero);
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            selectionBounds.Encapsulate(r.bounds);
        }
    }

    

    
}


