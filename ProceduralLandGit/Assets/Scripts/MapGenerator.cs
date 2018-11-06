using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public enum DrawMode { NoiseMap, ColorMap, Mesh };
    public DrawMode drawMode;

    const int mapChunkSize = 241; // 241-1 = 240 and is easily dividable
    [Range(0, 6)]
    public int meshSimplification;
    public float noiseScale;
    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;
    public int seed;
    public Vector2 offset;

    // Mesh
    public float meshHeightMultiplier;
    public AnimationCurve meshHeightCurve;

    public bool autoUpdate;
    public bool region;
    public bool aiMove;

    public TerrainType[] regions;
    public CustomGradient heightColors;


    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapChunkSize, mapChunkSize, seed, noiseScale, octaves, persistance, lacunarity, offset);

        Color[] colorMap = new Color[mapChunkSize * mapChunkSize];
        for (int y = 0; y < mapChunkSize; y++)
        {
            for (int x = 0; x < mapChunkSize; x++)
            {
                float currentHeight = noiseMap[x, y];
                if (aiMove)
                {
                    for (int i = 0; i < regions.Length; i++)
                    {
                        if (currentHeight <= 0.7)
                        {
                            colorMap[y * mapChunkSize + x] = Color.blue;
                            break;
                        }
                        else
                        {
                            colorMap[y * mapChunkSize + x] = Color.red;
                            break;
                        }
                    }

                }
                else if (!region)
                {
                    for (int i = 0; i < heightColors.NumKeys; i++)
                    {
                        if (currentHeight <= heightColors.GetKey(i).Time)
                        {
                            int left = i;
                            int right = i + 1;
                            if (right == heightColors.NumKeys)
                                right = i;

                            float blendTime = Mathf.InverseLerp(heightColors.GetKey(left).Time, heightColors.GetKey(right).Time, currentHeight);
                            Color thisColor =  Color.Lerp(heightColors.GetKey(left).Color, heightColors.GetKey(right).Color, blendTime);
                            colorMap[y * mapChunkSize + x] = thisColor;
                            break;
                        }
                    }
                }
                
                else
                {
                    for (int i = 0; i < regions.Length; i++)
                    {
                        if (currentHeight <= regions[i].height)
                        {
                            colorMap[y * mapChunkSize + x] = regions[i].color;
                            break;
                        }
                    }
                }
                

                    
            }
            MapDisplay display = FindObjectOfType<MapDisplay>();

            if (drawMode == DrawMode.NoiseMap)
                display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
            else if (drawMode == DrawMode.ColorMap)
                display.DrawTexture(TextureGenerator.TextureFromColorMap(colorMap, mapChunkSize, mapChunkSize));
            else if (drawMode == DrawMode.Mesh)
                display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap,meshHeightMultiplier, meshHeightCurve, meshSimplification), TextureGenerator.TextureFromColorMap(colorMap, mapChunkSize, mapChunkSize));
        }


    }

    void OnValidate()
    {
        if (lacunarity < 1)
            lacunarity = 1;
        if (octaves < 0)
            octaves = 0;
    }
}
    [System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public Color color;
}
