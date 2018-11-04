using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GUISkin Resource, Orders;
    private const int orderBarWidth = 1000, resourceBarHeight = 1000;
    private Player player;


    // Use this for initialization
    void Start()
    {
        player = transform.root.GetComponent<Player>();
    }

    private void DrawOrderBar()
    {
        GUI.skin = Orders;
        GUI.BeginGroup(new Rect(Screen.width - orderBarWidth, resourceBarHeight, orderBarWidth, Screen.height - resourceBarHeight));
        GUI.Box(new Rect(0, 0, orderBarWidth, Screen.height - resourceBarHeight), "");
        GUI.EndGroup();

    }

    private void DrawResourceBar()
    {
        GUI.skin = Resource;
        GUI.BeginGroup(new Rect(0, 0, Screen.width, resourceBarHeight));
        GUI.Box(new Rect(0, 0, Screen.width, resourceBarHeight), "");
        GUI.EndGroup();

    }

    void OnGui()
    {
        if (player && player.human)
        {
            DrawOrderBar();
            DrawResourceBar();
        }
    }
}
