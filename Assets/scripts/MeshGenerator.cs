using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{

    //public float noise;
    public GameObject grass;

    //these are used to draw the mesh on screen.
    public MeshFilter meshFilter;
    public MeshRenderer meshRender;
    public MeshCollider collider;

    //material for terrain
    public Material Floor;

    //random multiplier for perlin noise.
    public float randMultiplier;

    //allows use to call from and create meshData class
    MeshData terrainData;

    //sets the size of the terrain and number of vertices needed.
    public float[,] Map = new float[60, 60];


    public GameObject tree;
    public GameObject stump;


     GameObject[] objects;

    //variables used to create random spacing between trees.

    Vector3 offset;

    //sets the mesh 
    public Mesh mesh;

    int[] randPlacementX;
    int[] randPlacementY;

    public List<GameObject> objectList;

    // Start is called before the first frame update
    public void Start()
    {

        randPlacementX = new int[]
        {
           Random.Range(25,40), Random.Range(50, 64), Random.Range(25, 40), Random.Range(88, 96), Random.Range(80, 99)
        };

        randPlacementY = new int[]
        {
            Random.Range(25,46), Random.Range(68, 75), Random.Range(90, 98), Random.Range(25, 40), Random.Range(80, 99)
        };

        objects = new GameObject[]
        {
            tree,
            stump,
            grass
        };

        

        //creates a new terrain
        terrainData = GenerateTerrainMesh(Map, randMultiplier);

        //draws the terrain to the screen
        drawMesh(terrainData);

        //adds trees to the screen

        objectList = new List<GameObject>();


        //creates the mesh of the terrain.
        mesh = terrainData.createMesh();

    }


    public void drawMesh(MeshData meshdata)
    {
        meshFilter.sharedMesh = meshdata.createMesh();
        meshRender.sharedMaterial = Floor;
        collider.sharedMesh = meshdata.createMesh();
    }

    public MeshData GenerateTerrainMesh(float[,] MapSize, float randMult)
    {
        //gets the width and the height of the map.
        int width = MapSize.GetLength(0); // x
        int height = MapSize.GetLength(1); // z
        


        //calls a new meshData to be used to generate the mesh to map.
        MeshData meshData = new MeshData(width, height);

        int vertexIndex = 0;
        randMult = Random.Range(0.4f, 0.8f);
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                
                //noise = Mathf.PerlinNoise(j * randMult, i * randMult) * 2;

                //sets the vertices to positions int the array, to create a 2D plane.
               
                meshData.vertices[vertexIndex] = new Vector3(j, 0, i);
                //Debug.Log("terrain y " + meshData.vertices[vertexIndex].y);
                offset = new Vector3(Random.Range(4f, 7f), 0, Random.Range(4f, 7f));
                Vector3 grassoffset = new Vector3(Random.Range(1f, 3f), 0, Random.Range(1f, 3f));

                //make sure the position is set properly for the trees on the terrain
              
                Vector3 grassposition = new Vector3(j * 2f, 0, i * 2f);
                if (i <= 35 && j <= 35)
                {
                    Vector3 position = new Vector3(j * 4f, 0, i * 4f);
                    objectList.Add(Instantiate(objects[0], position + offset, Quaternion.identity));
                   
                }
                if (i <= 120 && j <= 120)
                {
                    objectList.Add(Instantiate(objects[2], grassposition + grassoffset, Quaternion.identity));
                    //Debug.Log("grass y " + grassposition.y);
                }
                if (i < 1 && j < 1)
                {
                    for (int k = 0; k < randPlacementX.GetLength(0); k++)
                    {
                        objectList.Add(Instantiate(objects[1], new Vector3(randPlacementX[k], 0, randPlacementY[k]) + offset, Quaternion.identity));
                    }
                }
                

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
            triangles = new int[(meshWidth) * (meshHeight) * 6];
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
}
