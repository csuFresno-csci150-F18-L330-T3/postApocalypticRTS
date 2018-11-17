using UnityEngine;

public class GenerateWalls : MonoBehaviour{
    public int width = 512;
    public int height = 512;
    public float scale = 20f;
    public int wallScale = 4;
    public float xOffset = 0f;
    public float yOffset = 0f;
    public float threshold = 50f;
    public GameObject wall;

	void Start () {
        if (xOffset == 0f)
            xOffset = Random.Range(0f, 999999f);
        if (yOffset == 0f)
            yOffset = Random.Range(0f, 999999f);

        threshold = (threshold / 100);
        Debug.Log(threshold);
        Texture2D textureMap = GenTexture();
        for (int x = 0; (x*wallScale) < width; x++)
        {
            for (int y = 0; (y*wallScale) < height; y++)
            {
                Color c = new Color(threshold, threshold, threshold);
                if (textureMap.GetPixel((x*wallScale), (y*wallScale)).b >= c.b)
                {
                    Vector3 pos = new Vector3((x * wallScale) - width / 2f + .5f, (y * wallScale) - height / 2f + .5f, 0f);
                    Instantiate(wall, pos, Quaternion.identity, transform);
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
        float xCoord = (float)x / width * scale + xOffset;
        float yCoord = (float)y / height * scale + yOffset;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
