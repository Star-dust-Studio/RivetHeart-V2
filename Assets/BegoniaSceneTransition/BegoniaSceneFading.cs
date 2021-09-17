using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BegoniaSceneFading : MonoBehaviour
{
    public Animator TransitionFade;
    //public string sceneName;

    // Update is called once per frame
    //void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        StartCoroutine(LoadScene());
    //    }
    //}

    IEnumerator LoadScene()
    {
        TransitionFade.SetTrigger("TransitionFadeEnd");
        yield return new WaitForSeconds(1.5f);
        //SceneManager.LoadScene(sceneName);
    }
}
