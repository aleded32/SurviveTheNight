using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> enemies;
    float timer = 0;
    bool enemySpawned = false;

    void Start()
    {
        
        enemies = new List<GameObject>();
        AddEnemy(enemy);
        


    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= -30 && enemySpawned == false)
        {
            Instantiate(enemies[0], spawnPos(), Quaternion.identity);
            timer = 0;
            enemySpawned = true;
        }
        else if (enemySpawned == true)
        {
            timer = 0;
        }
        else if (enemySpawned == false && timer > -30)
        {
            timer -= Time.deltaTime;
            
        }

        Debug.Log(timer);
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


