using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshGenerator  {

	public static MeshData GenerateTerrainMesh(float[,] heightMap, float heightMultiplier, AnimationCurve _heightCurve, int lod)
    {
        AnimationCurve heightCurve = new AnimationCurve(_heightCurve.keys);
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);
        float topLeftX = (width - 1) / -2f; // To center the mesh
        float topLeftZ = (width - 1) / 2f;

        int increment = lod * 2;
        if (increment == 0)
            increment = 1;

        int verticesPerLine = (width - 1) / increment + 1;
        MeshData meshData = new MeshData(verticesPerLine, verticesPerLine);
        int vertexIndex = 0;

        for(int y = 0; y < height; y+=increment)
        {
            for(int x = 0; x < width; x+=increment)
            {
                meshData.vertices[vertexIndex] = new Vector3(topLeftX + x, heightCurve.Evaluate(heightMap[x, y])*heightMultiplier, topLeftZ - y);
                meshData.uvs[vertexIndex] = new Vector2(x / (float)width, y / (float)height);
                //Create triangles, if not at edges
                if(x < width-1 && y < height - 1)
                {
                    meshData.AddTriangle(vertexIndex, vertexIndex + 1 + verticesPerLine, vertexIndex + verticesPerLine);
                    meshData.AddTriangle(vertexIndex + 1 + verticesPerLine, vertexIndex, vertexIndex + 1);
                }
                vertexIndex++;
            }
        }
        return meshData;
    }
}

public class MeshData
{
    public Vector3[] vertices;
    public int[] triangles;
    public Vector2[] uvs;
    int triangleIndex;


    public MeshData(int meshWidth, int meshHeight)
    {
        vertices = new Vector3[meshWidth * meshHeight];
        triangles = new int[(meshWidth - 1) * (meshHeight - 1) * 6];
        uvs = new Vector2[meshWidth * meshHeight];
    }

    public void AddTriangle(int a, int b, int c)
    {
        // Add triangle at indexes and update next index
        triangles[triangleIndex] = a;
        triangles[triangleIndex + 1] = b;
        triangles[triangleIndex + 2] = c;
        triangleIndex += 3;
    }

    public Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
        return mesh;
    }
}
