using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> enemies;

    void Start()
    {
        
        enemies = new List<GameObject>();
        AddEnemy(enemy);

        Debug.Log(enemies.Count);

        Instantiate(enemies[0], spawnPos(), Quaternion.identity);

    }

    List<GameObject> AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
        return enemies;
    }

    public Vector3 spawnPos()
    {
        int randPosX = Random.Range(20, 120);
        int randPosZ = Random.Range(20, 120);

        Vector3 pos = new Vector3(randPosX, 1f, randPosZ);

        return pos;
    }
}


