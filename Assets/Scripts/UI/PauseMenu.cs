using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
        Debug.Log("Paused");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Debug.Log("Resumed");
    }

    public void ButtonQuitGame()    //quit menu
    {
        SceneManager.LoadScene(0);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
