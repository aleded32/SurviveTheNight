using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator
{

    public float noise;

    public MeshData GenerateTerrainMesh(float[,] MapSize, float randMult)
    {
        //gets the width and the height of the map.
        int width = MapSize.GetLength(0); // x
        int height = MapSize.GetLength(1); // z
        


        //calls a new meshData to be used to generate the mesh to map.
        MeshData meshData = new MeshData(width, height);

        int vertexIndex = 0;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                //calculates the random use of perlin noise to generate slight hills
                noise = Mathf.PerlinNoise(j * randMult, i * randMult) * 2.0f;

                //sets the vertices to positions int the array, to create a 2D plane.
                meshData.vertices[vertexIndex] = new Vector3(j, noise, i);
               
                //calculates the terrain within the map size (stops it from generating it outside of scope)
                if (j < width - 1 && i < height - 1)
                {
                   //adds triangles to each position in the map
                   meshData.AddTriangle(vertexIndex, vertexIndex + width + 1, vertexIndex + width);
                   meshData.AddTriangle(vertexIndex  + width + 1, vertexIndex, vertexIndex + 1);

                }

                vertexIndex++;
               
            }
        }
        
        return meshData;
    }
}

//holds meshData that allows mesh to be created
public class MeshData
{
    //vertices 
    public Vector3[] vertices;

    //triangle array. keeps count of all the triangles created.
    public int[] triangles;

    //index of triangle array
    public int triIndex;

    //constructor for meshdata class
    public MeshData(int meshWidth, int meshHeight)
    {
        //maps the vertices array to the size of the map.
        vertices = new Vector3[meshWidth * meshHeight];
        //maps the triangles to the size of the map.
        triangles = new int[(meshWidth) * (meshHeight) *6];
    }

    //adds a vertices to calculate a triangle and iterates the next triangle
    public void AddTriangle(int a, int b, int c)
    {
        triangles[triIndex + 2] = a;
        triangles[triIndex + 1] = b;
        triangles[triIndex] = c;

        triIndex += 3;

        
    }


    //this creates a mesh to be used for the terrain 
    public Mesh createMesh()
    {
        Mesh mesh = new Mesh();

        //sets vertices and trianlges created to the mesh.
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        //recalulates normals of traingles and vertices for ligthing purposes
        mesh.RecalculateNormals();

        return mesh;
    }
}
