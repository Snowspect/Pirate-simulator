using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise{

    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int  octaves, float persistance, float lacunarity, Vector2 offset)
    {
        // Create float array to hold 
        float[,] noiseMap = new float[mapWidth,mapHeight];

        //Generate pseudo random number
        System.Random prng = new System.Random(seed);

        // Octaves - different noise levels which layered will create a more detailed result noise

        // Lacunarity - Controls the frequency of each octave (how much it will affect the final outcome)
        //              The first octave has the greatest effect and sets the overall outline of the map. 
        // Example: 1 octave = mountain, 2 second octave = boulders, 3 octave = small rocks, 4 octave = grass etc.

        // Persistance - Tells how fast the amplitude of the octaves decreases for each step

        // Lacunarity - Amount of details
        // Persistance - The impact of each detail

         


        //Octave offsets
        Vector2[] octaveOffsets = new Vector2[octaves];
        for(int i=0; i<octaves; i++)
        {
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(-100000, 100000) + offset.y;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        if (scale <= 0)
            scale = 0.0001f;

        //Normalizing values
        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        // Half values to zoom in/out from center
        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        for( int y = 0; y < mapHeight; y++)
        {
            for( int x=0; x < mapWidth; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                //  Octaves
                for(int i = 0; i < octaves; i++)
                {
                    float sampleX = (x-halfWidth) / scale * frequency + octaveOffsets[i].x;
                    float sampleY = (y-halfHeight) / scale * frequency + octaveOffsets[i].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY)*2-1; // Create a perlin noise value  [-1,1]

                    noiseHeight += perlinValue * amplitude;
                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                // Check if new min/max values have been found
                if (noiseHeight < minNoiseHeight)
                    minNoiseHeight = noiseHeight;
                else if (noiseHeight > maxNoiseHeight)
                    maxNoiseHeight = noiseHeight;
                noiseMap[x, y] = noiseHeight;
            }
        }

        // Normalize noisemap points from -1 to 1
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }

                return noiseMap;
    }
}
