using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    float timeToMove = 5;

    public Vector3 currentPos;
    Vector3 target;
    public GameObject player;
    float enemyRadius;
    float speed;

    public void Start()
    {
        target = targetPos();
        player = GameObject.Find("player");
        currentPos = transform.position;
        enemyRadius = 10f;
    }

    // Update is called once per frame
    void Update()
    {



        moveEnemy();
        
    }

    public void moveEnemy()
    {

        Debug.Log(speed);


        if (checkRange() == false)
        {
            speed = 8f;
            currentPos = Vector3.MoveTowards(currentPos, target, speed * Time.deltaTime);
            transform.position = currentPos;
        }
        else if (checkRange() == true)
        {
            speed = 1.5f;
            currentPos = Vector3.MoveTowards(currentPos, player.transform.position, speed * Time.deltaTime);
            transform.position = currentPos;
        }

       

        if (timeToMove <= 0)
        {
            target = targetPos();
            timeToMove = 5f;
        }
        timeToMove -= Time.deltaTime;

        
        
       
    }


    public bool checkRange()
    {

        if (Vector3.Distance(player.transform.position, currentPos) <= enemyRadius)
        {

            return true;
        }
        else
        {
            return false;
        }

       
    }

    public Vector3 targetPos()
    {
        int randPosX = Random.Range(20, 120);
        int randPosZ = Random.Range(20, 120);

        Vector3 pos = new Vector3(randPosX, 1f, randPosZ);

        return pos;
    }
}
