using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void ButtonStart()
    {
        SceneManager.LoadScene(1);  //load the scene, the scene(1) is manage from unity.
    }

    public void ButtonQuit()    //quit menu
    {
        Application.Quit();
    
    }

    public void ButtonMenu()
    {
        SceneManager.LoadScene(0);
    }

    
}
