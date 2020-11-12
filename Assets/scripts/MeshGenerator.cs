using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator
{

    public float noise;

    public MeshData GenerateTerrainMesh(float[,] MapSize, float randMult)
    {
        int width = MapSize.GetLength(0); // x
        int height = MapSize.GetLength(1); // z
        



        MeshData meshData = new MeshData(width, height);
        int vertexIndex = 0;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                noise = Mathf.PerlinNoise(j * randMult, i * randMult) * 2.0f;
                meshData.vertices[vertexIndex] = new Vector3(j, noise, i);
               

                if (j < width - 1 && i < height - 1)
                {
                    meshData.AddTriangle(vertexIndex, vertexIndex + width + 1, vertexIndex + width);
                    meshData.AddTriangle(vertexIndex  + width + 1, vertexIndex, vertexIndex + 1);
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

    int triIndex;

    public MeshData(int meshWidth, int meshHeight)
    {
        vertices = new Vector3[meshWidth * meshHeight];
        triangles = new int[(meshWidth - 1) * (meshHeight-1) *6];
    }

    public void AddTriangle(int a, int b, int c)
    {
        triangles[triIndex] = c;
        triangles[triIndex + 1] = b;
        triangles[triIndex + 2] = a;

        triIndex += 3;

        
    }

    public Mesh createMesh()
    {
        Mesh mesh = new Mesh();


        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
}
