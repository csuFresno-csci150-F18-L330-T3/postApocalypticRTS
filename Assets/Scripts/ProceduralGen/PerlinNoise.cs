using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour {

    public int width = 512;
    public int height = 512;
    public float scale = 20f;
    public float xOffset = 0f;
    public float yOffset = 0f;

	// Use this for initialization
	void Start () {
        xOffset = Random.Range(0f, 999999f);
        yOffset = Random.Range(0f, 999999f);
	}

    Texture2D GenTexture ()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalcColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }
        return texture;
    }

    Color CalcColor(int x, int y)
    {
        float xCoord = (float)x / width * scale + xOffset;
        float yCoord = (float)y / height * scale + yOffset;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
