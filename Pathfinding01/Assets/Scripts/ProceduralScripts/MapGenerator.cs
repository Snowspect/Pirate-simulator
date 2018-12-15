using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
public class MapGenerator : MonoBehaviour
{
    public List<NoiseData> noiseLevels;

    public enum DrawMode { NoiseMap, ColorMap, Mesh, Falloff };
    public DrawMode drawMode;

    [Range(0, MeshGenerator.numSupportedChunkSizes - 1)]
    public int chunkSizeIndex;

    [Range(0, MeshGenerator.numberOfSupportedLODs - 1)]
    public int meshSimplification;

    public TerrainData terrainData;
    private NoiseData noiseData;
    public TextureData textureData;
    public Material terrainMaterial;

    public bool autoUpdate;
    public bool region;
    public bool aiMove;

    public GameObject spawnPlayer;
    public GameObject spawnAI;

    //public TerrainType[] regions;
    public CustomGradient heightColors;
    float[,] falloffMap;
    Queue<MapThreadInfo<MapData>> mapDataThreadInfoQueue = new Queue<MapThreadInfo<MapData>>();
    Queue<MapThreadInfo<MeshData>> meshDataThreadInfoQueue = new Queue<MapThreadInfo<MeshData>>();

    /*private void Awake()
    {
        falloffMap = FalloffGenerator.GenerateFalloffMap(mapChunkSize);
    }
    */

    private void Awake()
    {

        string mapName = "Map";
        int levelChoice = 1; //must be between 1-10 //this should be dependent on userData variable

        noiseData = noiseLevels[levelChoice - 1]; //To meet the condition of the zero-indexed list

        MeshFilter ms;
        foreach (var level in noiseLevels)
        {
            if (level.name.Equals("Level0" + levelChoice))
            {
                mapName = mapName + 0 + levelChoice;
                Debug.Log("mapname in first if statement : " + mapName);
                ms = GameObject.Find(mapName).GetComponent<MeshFilter>();
                ms.GetComponent<Renderer>().enabled = true;
                ms.GetComponent<Collider>().enabled = true;
            }
        }

        if (noiseData.name.Equals("Level01"))
        {
            spawnPlayer.transform.position = new Vector3(-268, 4, -219); //DONE
            spawnAI.transform.position = new Vector3(224, 4, -219); //DONE
        }
        else if (noiseData.name.Equals("Level02"))
        {
            spawnPlayer.transform.position = new Vector3(236, 0, -266); //DONE
            spawnAI.transform.position = new Vector3(-227, 0, 44); //DONE
        }
        else if (noiseData.name.Equals("Level03"))
        {
            spawnPlayer.transform.position = new Vector3(-168, 0, 148); //DONE
            spawnAI.transform.position = new Vector3(253, 0, 198); //DONE
        }
        else if (noiseData.name.Equals("Level04"))
        {
            spawnPlayer.transform.position = new Vector3(29, 0, 36); //DONE
            spawnAI.transform.position = new Vector3(-173, 0, 160); //DONE
        }
        else if (noiseData.name.Equals("Level05"))
        {
            spawnPlayer.transform.position = new Vector3(-114, 0, 90); //DONE
            spawnAI.transform.position = new Vector3(45, 0, -223); //DONE
        }
        else if (noiseData.name.Equals("Level06"))
        {
            spawnPlayer.transform.position = new Vector3(195, 0, -165); //DONE
            spawnAI.transform.position = new Vector3(-60, 0, 40); //DONE
        }
        else if (noiseData.name.Equals("Level07"))
        {
            spawnPlayer.transform.position = new Vector3(-267, 0, -165); //DONE
            spawnAI.transform.position = new Vector3(96, 0, 120); //DONE
        }
        else if (noiseData.name.Equals("Level08"))
        {
            spawnPlayer.transform.position = new Vector3(17, 0, -165); //DONE
            spawnAI.transform.position = new Vector3(-293, 0, -289); //DONE
        }
        else if (noiseData.name.Equals("Level09"))
        {
            spawnPlayer.transform.position = new Vector3(77, 0, -141); //DONE 
            spawnAI.transform.position = new Vector3(288, 0, 59); //DONE
        }

        textureData.ApplyToMaterial(terrainMaterial);
        textureData.UpdateMeshHeights(terrainMaterial, terrainData.minHeight, terrainData.maxHeight);
    }

    void OnValuesUpdated()
    {
        if (!Application.isPlaying)
        {
            DrawMapInEditor();
        }
    }

    void OnTexturevaluesUpdated()
    {
        textureData.ApplyToMaterial(terrainMaterial);
    }
    public int mapChunkSize
    {
        get
        {
            return MeshGenerator.supportedChunkSizes[chunkSizeIndex];
        }
    } // 241-1 = 240 and is easily dividable

    public void DrawMapInEditor()
    {
        textureData.UpdateMeshHeights(terrainMaterial, terrainData.minHeight, terrainData.maxHeight);
        MapData mapData = GenerateMapData(Vector2.zero);
        MapDisplay display = FindObjectOfType<MapDisplay>();

        if (drawMode == DrawMode.NoiseMap)
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(mapData.heightMap));
        //belse if (drawMode == DrawMode.ColorMap)
        // display.DrawTexture(TextureGenerator.TextureFromColorMap(mapData.colorMap, mapChunkSize, mapChunkSize));
        else if (drawMode == DrawMode.Mesh)
            display.DrawMesh(MeshGenerator.GenerateTerrainMesh(mapData.heightMap, terrainData.meshHeightMultiplier, terrainData.meshHeightCurve, meshSimplification));//, TextureGenerator.TextureFromColorMap(mapData.colorMap, mapChunkSize, mapChunkSize));
        else if (drawMode == DrawMode.Falloff)
        {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(FalloffGenerator.GenerateFalloffMap(mapChunkSize)));
        }
    }

    public void RequestMapData(Vector2 centre, Action<MapData> callBack)
    {
        ThreadStart threadStart = delegate
        {
            MapDataThread(centre, callBack);
        };

        new Thread(threadStart).Start();
    }
    void MapDataThread(Vector2 centre, Action<MapData> callBack)
    {
        MapData mapData = GenerateMapData(centre);
        lock (mapDataThreadInfoQueue)
        {
            mapDataThreadInfoQueue.Enqueue(new MapThreadInfo<MapData>(callBack, mapData));
        }

    }
    public void RequestMeshData(MapData mapData, int lod, Action<MeshData> callback)
    {
        ThreadStart threadStart = delegate {
            MeshDataThread(mapData, lod, callback);
        };
        new Thread(threadStart).Start();
    }

    void MeshDataThread(MapData mapData, int lod, Action<MeshData> callBack)
    {
        MeshData meshData = MeshGenerator.GenerateTerrainMesh(mapData.heightMap, terrainData.meshHeightMultiplier, terrainData.meshHeightCurve, lod);
        lock (meshDataThreadInfoQueue)
        {
            meshDataThreadInfoQueue.Enqueue(new MapThreadInfo<MeshData>(callBack, meshData));
        }
    }

    void Update()
    {
        if (mapDataThreadInfoQueue.Count > 0)
        {
            for (int i = 0; i < mapDataThreadInfoQueue.Count; i++)
            {
                MapThreadInfo<MapData> threadInfo = mapDataThreadInfoQueue.Dequeue();
                threadInfo.callBack(threadInfo.parameter);
            }
        }
        if (meshDataThreadInfoQueue.Count > 0)
        {
            for (int i = 0; i < meshDataThreadInfoQueue.Count; i++)
            {
                MapThreadInfo<MeshData> threadInfo = meshDataThreadInfoQueue.Dequeue();
                threadInfo.callBack(threadInfo.parameter);
            }
        }
    }
    MapData GenerateMapData(Vector2 centre)
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapChunkSize + 2, mapChunkSize + 2, noiseData.seed, noiseData.noiseScale, noiseData.octaves, noiseData.persistance, noiseData.lacunarity, centre + noiseData.offset, noiseData.normalizeMode);


        //Color[] colorMap = new Color[mapChunkSize * mapChunkSize];
        if (terrainData.useFalloff)
        {
            if (falloffMap == null)
            {
                falloffMap = FalloffGenerator.GenerateFalloffMap(mapChunkSize + 2);
            }

            for (int y = 0; y < mapChunkSize + 2; y++)
            {
                for (int x = 0; x < mapChunkSize + 2; x++)
                {
                    if (terrainData.useFalloff)
                    {
                        noiseMap[x, y] = Mathf.Clamp01(noiseMap[x, y] - falloffMap[x, y]);
                    }
                    float currentHeight = noiseMap[x, y];
                    /*if (aiMove)
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
                            if (currentHeight >= regions[i].height)
                            {
                                colorMap[y * mapChunkSize + x] = regions[i].color;
                            }
                            else
                                break;
                        }
                    }
                    */


                }
            }
        }
        return new MapData(noiseMap);//, colorMap);
    }

    void OnValidate()
    {
        if (terrainData != null)
        {
            terrainData.OnValuesUpdated -= OnValuesUpdated;
            terrainData.OnValuesUpdated += OnValuesUpdated;
        }
        if (noiseData != null)
        {
            noiseData.OnValuesUpdated -= OnValuesUpdated;
            noiseData.OnValuesUpdated += OnValuesUpdated;
        }

        if (textureData != null)
        {
            textureData.OnValuesUpdated -= OnTexturevaluesUpdated;
            textureData.OnValuesUpdated += OnTexturevaluesUpdated;
        }
        //falloffMap = FalloffGenerator.GenerateFalloffMap(mapChunkSize);
    }

    struct MapThreadInfo<T>
    {
        public readonly Action<T> callBack;
        public readonly T parameter;

        public MapThreadInfo(Action<T> callBack, T parameter)
        {
            this.callBack = callBack;
            this.parameter = parameter;
        }
    }
}
/*
    [System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public Color color;
}
 
    */
public struct MapData
{
    public readonly float[,] heightMap;
    //public readonly Color[] colorMap;

    public MapData(float[,] heightMap)//, Color[] colorMap)
    {
        this.heightMap = heightMap;
        //this.colorMap = colorMap;
    }
}