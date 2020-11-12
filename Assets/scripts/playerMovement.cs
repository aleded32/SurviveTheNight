using System.Collections;
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
    bool isTorchOn = true;

    public void Start()
    {
        MinY = -45;
        MaxY = 45;
    }


    // Update is called once per frame
    void Update()
    {

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isTorchOn)
            {
                torchObj.GetComponent<Light>().intensity = 1.5f;
                isTorchOn = false;
            }
            else if(!isTorchOn)
            {
                torchObj.GetComponent<Light>().intensity = 0.0f;
                isTorchOn = true;
            }
            
           
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerRotate();

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
        transform.rotation = Quaternion.Euler(0, rotations().x, 0);
        cameraObj.transform.rotation = Quaternion.Euler(rotations().y, rotations().x, 0);
        torchObj.transform.rotation = Quaternion.Euler(rotations().y, rotations().x, 0);
    }

    Vector3 rotations()
    {
        horizontal += 50.0f * Input.GetAxis("Mouse X") * Time.deltaTime;
        vertical -= 50.0f * Input.GetAxis("Mouse Y") * Time.deltaTime;

        vertical = Mathf.Clamp(vertical, MinY, MaxY);

        return new Vector3(horizontal, vertical);

    }

}
