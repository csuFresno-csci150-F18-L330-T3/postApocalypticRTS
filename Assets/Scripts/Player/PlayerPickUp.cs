using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUp : MonoBehaviour {

    public Text countText;          //Store a reference to the UI Text component which will display the number of pickups collected.
    public Text winText;            //Store a reference to the UI Text component which will display the 'You win' message.

    private int count;

    // Use this for initialization
    void Start () {
        count = 0;
        winText.text = "";
        SetCountText();
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

            count = count + 1;
            SetCountText();
        }

    }
    void SetCountText()
    {
        //Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
        countText.text = "Count: " + count.ToString();

        //Check if we've collected all 12 pickups. If we have...
        if (count >= 5)
            //... then set the text property of our winText object to "You win!"
            winText.text = "You win!";
    }

}
