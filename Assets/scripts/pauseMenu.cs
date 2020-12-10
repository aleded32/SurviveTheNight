using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public bool pauseOn = false;
    public GameObject pause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("startbutton"))
        {

            if (pauseOn == false)
            {
                pause.SetActive(true);
                Time.timeScale = 0f;
                pauseOn = true;
            }
            else
            {
                pause.SetActive(false);
                Time.timeScale = 1f;
                pauseOn = false;

            }



        }

        if (pauseOn == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
    }
}
