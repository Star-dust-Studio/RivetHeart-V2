using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionExit : MonoBehaviour
{
    public string sceneName;
    [SerializeField] private string newScenePassword;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Player")
        {
            PlayerManager.instance.scenePassword = newScenePassword;
            SceneManager.LoadScene(sceneName);
        }
    }

}
