using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    public bool pauseOn = false;
    public GameObject pause;
    public Slider senXsliderPause;
    public Slider senYsliderPause;
    public playerMovement player;
    public soundManager soundM;

    private void Start()
    {
        Time.timeScale = 1f;
  
        senXsliderPause.value = player.Xsensitivity;
        senYsliderPause.value = player.Ysensitivity;
    }

    void Update()
    {

        senXsliderPause.maxValue = 2f;
        senXsliderPause.minValue = 0.1f;
        senYsliderPause.maxValue = 2f;
        senYsliderPause.minValue = 0.1f;

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


    public void quitButton()
    {
        PlayerPrefs.SetFloat("senX", player.Xsensitivity);
        PlayerPrefs.SetFloat("senY", player.Ysensitivity);
        PlayerPrefs.SetFloat("sound", soundM.soundSliderPause.value);
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }

    public void senX()
    {
        player.Xsensitivity = senXsliderPause.value;
    }

    public void senY()
    {
        player.Ysensitivity = senYsliderPause.value;
    }
}
