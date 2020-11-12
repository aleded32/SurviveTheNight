using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawTerrain : MonoBehaviour
{

    MeshGenerator terrain = new MeshGenerator();
    public MeshFilter meshFilter;
    public MeshRenderer meshRender;
    public MeshCollider collider;
    public Material Floor;
    public float randMultiplier;
    MeshData terrainData;
    public float[,] Map = new float[60,60];
    public GameObject tree;
    int treeSpacingX;
    int treeSpacingZ;
    Vector3 offset;
    public Mesh mesh;
  

    // Start is called before the first frame update
    public void Start()
    {
        randMultiplier = Random.Range(0.08f, 0.2f);
        terrainData = terrain.GenerateTerrainMesh(Map, randMultiplier);
        drawMesh(terrainData);
        
        addTree();
        mesh = terrainData.createMesh();

    }

    public void drawMesh(MeshData meshdata)
    {
        meshFilter.sharedMesh = meshdata.createMesh();
        meshRender.sharedMaterial = Floor;
        collider.sharedMesh = meshdata.createMesh();
    }

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

                Vector3 position = new Vector3(i, terrain.noise - 0.5f, j);
                treelist.Add(Instantiate(tree, position + offset, Quaternion.identity));
            }
        }
        return treelist;

    }

    

    

}
