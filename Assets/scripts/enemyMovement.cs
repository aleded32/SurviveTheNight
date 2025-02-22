﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyMovement : MonoBehaviour
{

    float timeToMove = 5;

    public Vector3 currentPos;
    Vector3 target;
    public GameObject player;
    public Animator An;
    float enemyRadius;
    float speed;
    AudioSource audioEnemy;


    public void Start()
    {
        target = targetPos();
        player = GameObject.Find("player");
        currentPos = transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        audioEnemy = GetComponent<AudioSource>();

        moveEnemy();

        if (isGameOver() == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("gameOver", LoadSceneMode.Single);
        }
        
    }

    public void moveEnemy()
    {

       
        An.SetBool("isRunning", true);

        if (player.GetComponent<playerMovement>().isTorchOn == false)
        {
            enemyRadius = 8f;
        }
        else
        {
            enemyRadius = 12f;
        }

        if (checkRange() == false)
        {
            speed = 10f;
            currentPos = Vector3.MoveTowards(currentPos, target, speed * Time.deltaTime);
            transform.position = currentPos;
            transform.LookAt(target);
            if(audioEnemy.isPlaying)
                   audioEnemy.Stop();
        }
        else if (checkRange() == true)
        {
            speed = 3f;
            currentPos = Vector3.MoveTowards(currentPos, player.transform.position, speed * Time.deltaTime);
            transform.position = currentPos;
            transform.LookAt(player.transform.position);
            if(!audioEnemy.isPlaying)
                   audioEnemy.Play();
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

        Vector3 pos = new Vector3(randPosX, 0f, randPosZ);

        return pos;
    }

    bool isGameOver()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 2f)
        {
            audioEnemy.Stop();
            return true;

        }
        else
        {
            return false;
        }
    }
}
