﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    float velocity;
    float MinY, MaxY;
    float moveSpeed = 5f;
    public GameObject cameraObj;
    public GameObject torchObj;
    float horizontal, vertical;
    public bool isTorchOn;
    public float Xsensitivity;
    public float Ysensitivity;
    public bool isPaused;
    public GameObject menuSystem;

    public void Start()
    {
        MinY = -45;
        MaxY = 45;

        transform.position = new Vector3(Random.Range(18, 127), 0, Random.Range(18,127));
        StartTorch();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    {
        moveJoysticks();


        if (transform.position.x < 15)
        {
            transform.position = new Vector3(15, transform.position.y, transform.position.z);
        }
        else if (transform.position.z < 15)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 15);
        }
        else if (transform.position.x > 130)
        {
            transform.position = new Vector3(130, transform.position.y, transform.position.z);
        }
        else if (transform.position.z > 130)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 130);
        }

        cameraPos();
        torchPos();

        velocity = moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            forward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            left();
        }
        if (Input.GetKey(KeyCode.D))
        {
            right();
        }
        if (Input.GetKey(KeyCode.S))
        {
            back();
        }
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("Abutton"))
        {

            torch();           
        }

        isPaused = menuSystem.GetComponent<pauseMenu>().pauseOn;

        
        
        
        playerRotate();

    }

    void moveJoysticks()
    {
        float xJoy = Input.GetAxis("HorizontalLJ") * velocity;
        float zJoy = Input.GetAxis("VerticalLJ") * velocity;

        transform.Translate(xJoy, 0, zJoy);

    }

    void forward()
    {
        transform.Translate(Vector3.forward * velocity);
    }

    void left()
    {
        transform.Translate(Vector3.left * velocity);
    }
    void right()
    {
        transform.Translate(Vector3.right * velocity);
    }
    void back()
    {
        transform.Translate(Vector3.back * velocity);
    }

    void cameraPos()
    {
        cameraObj.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
    }
    void torchPos()
    {
        torchObj.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
    }

    void playerRotate()
    {
        transform.rotation = Quaternion.Euler(0, rotations().y, 0);
        cameraObj.transform.rotation = Quaternion.Euler(rotations());
        torchObj.transform.rotation = Quaternion.Euler(rotations());
        cameraObj.transform.rotation = Quaternion.Euler(rotationsJoysticks());
        torchObj.transform.rotation = Quaternion.Euler(rotationsJoysticks());

    }

    Vector3 rotations()
    {
        horizontal += Xsensitivity * Input.GetAxis("Horizontal") * Time.deltaTime;
        vertical -= Ysensitivity * Input.GetAxis("Vertical") * Time.deltaTime;

        vertical = Mathf.Clamp(vertical, MinY, MaxY);

        return new Vector3(vertical, horizontal,0);

    }

    Vector3 rotationsJoysticks()
    {
        horizontal += Xsensitivity * Input.GetAxisRaw("HorizontalRJ") * Time.deltaTime;
        vertical -= Ysensitivity * Input.GetAxisRaw("VerticalRJ") * Time.deltaTime;

        vertical = Mathf.Clamp(vertical, MinY, MaxY);

        return new Vector3(vertical, horizontal, 0);

    }

    void torch()
    {
        if (!isTorchOn)
        {
            torchObj.GetComponent<Light>().intensity = 4f;
            isTorchOn = true;
        }
        else if (isTorchOn)
        {
            torchObj.GetComponent<Light>().intensity = 0.0f;
            isTorchOn = false;
        }
    }

    void StartTorch()
    {
        if (!isTorchOn)
        {
            torchObj.GetComponent<Light>().intensity = 0f;
            isTorchOn = false;
        }
        
    }


}
