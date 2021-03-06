﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerPickUp : MonoBehaviour
{

    public Text countText;          //Store a reference to the UI Text component which will display the number of pickups collected.
    public Text winText;            //Store a reference to the UI Text component which will display the 'You win' message.

    public static int count = 0;

    public bool isGameStart = true; //my boy freddie with the save

    // Use this for initialization
    void Start()
    {

        winText.text = "";
        count = 0;
        SetCountText();
    }


    // Update is called once per frame
    void Update()
    {
        SetCountText();
        if (isGameStart)
        {
            count = 0;
            isGameStart = false;
        }
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
        countText.text = "P.A.R.T.S. " + count.ToString();

        if (count >= 3)
        {
            //... then set the text property of our winText object to "You win!"
            count = 0;
            isGameStart = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}