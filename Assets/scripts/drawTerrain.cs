using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawTerrain : MonoBehaviour
{
    //creates a meshGenetor so the mesh can be draw.
    MeshGenerator terrain = new MeshGenerator();

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
    public float[,] Map = new float[60,60];

    
    public GameObject tree;

    //variables used to create random spacing between trees.
    int treeSpacingX;
    int treeSpacingZ;
    Vector3 offset;

    //sets the mesh 
    public Mesh mesh;
  

    // Start is called before the first frame update
    public void Start()
    {
        randMultiplier = Random.Range(0.08f, 0.2f);

        //creates a new terrain
        terrainData = terrain.GenerateTerrainMesh(Map, randMultiplier);

        //draws the terrain to the screen
        drawMesh(terrainData);

        //adds trees to the screen
        addTree();

        //creates the mesh of the terrain.
        mesh = terrainData.createMesh();

    }
    
    
    public void drawMesh(MeshData meshdata)
    {
        meshFilter.sharedMesh = meshdata.createMesh();
        meshRender.sharedMaterial = Floor;
        collider.sharedMesh = meshdata.createMesh();
    }

   //creates a list of trees to be spawned in.
    public List<GameObject> addTree()
    {
        List<GameObject> treelist = new List<GameObject>();
        for (int i = 25; i < 100; i += treeSpacingX)
        {
            treeSpacingX = Random.Range(5, 8);
            for (int j = 25; j < 100; j += treeSpacingZ)
            {
                treeSpacingZ = Random.Range(5, 8);
                offset = new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));

                //make sure the position is set properly for the trees on the terrain
                Vector3 position = new Vector3(i, terrain.noise - 0.5f, j);

                treelist.Add(Instantiate(tree, position + offset, Quaternion.identity));
            }
        }
        return treelist;

    }

    

    

}
