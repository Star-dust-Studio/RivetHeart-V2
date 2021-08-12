using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BegoniaExit : MonoBehaviour
{
    public string sceneName;
    [SerializeField]private string newScenePassword;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Player")
        {
            BegoniaPlayerMovement.instance.scenePassword = newScenePassword;
            SceneManager.LoadScene(sceneName);
        }
    }
}
