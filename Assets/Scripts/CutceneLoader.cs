using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CutceneLoader : MonoBehaviour
{
    public string nextScene;
    void OnEnable()
    {
        //Only specifting the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}
