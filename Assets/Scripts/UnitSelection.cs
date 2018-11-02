using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Utilities
{
    static Texture2D whiteTexture;
    public static Texture2D WhiteTexture
    {
        get
        {
            if (whiteTexture == null)
            {
                whiteTexture = new Texture2D(1, 1);
                whiteTexture.SetPixel(0, 0, Color.white);
                whiteTexture.Apply();
            }
            return whiteTexture;
        }
    }
    public static void DrawScreenRect(Rect rect, Color color)
    {
        GUI.color = color;
        GUI.DrawTexture(rect, WhiteTexture);
        GUI.color = Color.white;
    }
}

public class UnitSelection : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }
    // Update is called once per frame
    void Update() {

    }

}