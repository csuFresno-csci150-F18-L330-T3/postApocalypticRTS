﻿using UnityEngine;

public class GenerateWalls : MonoBehaviour{
    public int width = 512;
    public int height = 512;
    public float noiseScale = 20f;      //how fine/coarse noise is, higher = finer
    public int objectScale = 4;
    public float xOffset = 0f;
    public float yOffset = 0f;
    public float threshold = 50f;       //compared to the pixel hue generated by perlin noise (0 to 1)
    public float rawChance = 100f;      //raw chance an object will spawn
    public bool isWeighted = false;     //determines if the chance an object will spawn is weighted against itself
    public bool hardThreshold = true;   //if threshold should be checked before or after weighing
    public float weightedChance = 100f; //chance an object will spawn when weighted with the generated hue value (0 to 1)
                                        //a pixel with a hue of 0.8 has a 20% * weightedChance to spawn
    public GameObject wall;
    public Texture2D textureMap;        //used to pass the texturemap generated to other scripts, dont add textures in script window
    public float distanceFromPlayerBase = 10f;

	void Awake () {
        if (xOffset == 0f)
            xOffset = Random.Range(0f, 999999f);
        if (yOffset == 0f)
            yOffset = Random.Range(0f, 999999f);

        GameObject[] playerBases = GameObject.FindGameObjectsWithTag("PlayerBase");
        GameObject helicopter = GameObject.FindGameObjectWithTag("Helicopter");
        threshold = (threshold / 100);
        rawChance /= 100;
        weightedChance /= 100;
        Debug.Log(threshold);
        textureMap = GenTexture();            //generate map for perlin noise
        float minDistFromBase = 999999f;
        for (int x = 0; (x*objectScale) < width; x++)   //generation loop
        {
            for (int y = 0; (y*objectScale) < height; y++)
            {
                Color c = new Color(threshold, threshold, threshold);
                if (textureMap.GetPixel((x*objectScale), (y*objectScale)).b >= c.b && hardThreshold) //compares to threshold
                {
                    if (Random.value <= rawChance)
                    {
                        if (isWeighted == false)    //generation loop condition
                        {
                            Vector3 pos = new Vector3((x * objectScale) - width / 2f + .5f, (y * objectScale) - height / 2f + .5f, 0f);
                            foreach (GameObject pBase in playerBases)
                            {
                                Vector3 baseLoc = pBase.transform.position;
                                if (Vector3.Distance(baseLoc, pos) < minDistFromBase)
                                    minDistFromBase = Vector3.Distance(baseLoc, pos);
                            }
                            if (minDistFromBase > distanceFromPlayerBase && distanceFromPlayerBase < Vector3.Distance(pos, helicopter.transform.position))
                                Instantiate(wall, pos, Quaternion.identity, transform);
                            minDistFromBase = 999999f;
                        }
                        else if (Random.value >= (1f-(textureMap.GetPixel((x * objectScale), (y * objectScale)).b))/weightedChance)    //generation loop condition
                        {
                            Vector3 pos = new Vector3((x * objectScale) - width / 2f + .5f, (y * objectScale) - height / 2f + .5f, 0f);
                            foreach (GameObject pBase in playerBases)
                            {
                                Vector3 baseLoc = pBase.transform.position;
                                if (Vector3.Distance(baseLoc, pos) < minDistFromBase)
                                    minDistFromBase = Vector3.Distance(baseLoc, pos);
                            }
                            if (minDistFromBase > distanceFromPlayerBase && distanceFromPlayerBase < Vector3.Distance(pos, helicopter.transform.position))
                                Instantiate(wall, pos, Quaternion.identity, transform);
                            minDistFromBase = 999999f;
                        }
                    }
                }
                else if (!hardThreshold && isWeighted)
                {
                    float chance = textureMap.GetPixel((x * objectScale), (y * objectScale)).b;
                    chance = chance * weightedChance * 2 * Random.value;
                    if (chance >= threshold)    //generation loop condition
                    {
                        Vector3 pos = new Vector3((x * objectScale) - width / 2f + .5f, (y * objectScale) - height / 2f + .5f, 0f);
                        foreach (GameObject pBase in playerBases)
                        {
                            Vector3 baseLoc = pBase.transform.position;
                            if (Vector3.Distance(baseLoc, pos) < minDistFromBase && distanceFromPlayerBase > Vector3.Distance(pos, helicopter.transform.position))
                                minDistFromBase = Vector3.Distance(baseLoc, pos);
                        }
                        if (minDistFromBase > distanceFromPlayerBase)
                            Instantiate(wall, pos, Quaternion.identity, transform);
                        minDistFromBase = 999999f;
                    }
                }
            }
        }
	}

    Texture2D GenTexture()
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
        float xCoord = (float)x / width * noiseScale + xOffset;
        float yCoord = (float)y / height * noiseScale + yOffset;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
