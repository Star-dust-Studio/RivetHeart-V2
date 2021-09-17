using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(LoadScene);
    }

    public void LoadScene()
    {
        gameObject.SetActive(false);
        FindObjectOfType<LoadingScreenControl>().LoadScene(sceneToLoad);
    }
}
