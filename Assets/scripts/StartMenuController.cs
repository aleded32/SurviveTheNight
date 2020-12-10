using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Start is called before the first frame update
    public void startButton()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void optionsButton()
    {
        SceneManager.LoadScene("options", LoadSceneMode.Single);
    }

    public void quitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }

    public void instructionButton()
    {
        SceneManager.LoadScene("Instructions", LoadSceneMode.Single);
    }



    

}
