using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MapUIController : MonoBehaviour
{
    public Button MapPanel;

    ///[SerializeField]
    private bool openMap;

    // Start is called before the first frame update
    void Start()
    {
        openMap = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!openMap)
            {
                PlayerManager.instance.InfoVisibility(false);
                openMap = true;
                DisplayMapPanel();
            }
            else
            {
                PlayerManager.instance.InfoVisibility(true);
                openMap = false;
                HideMapPanel();
            }
        }
    }
        public void DisplayMapPanel()
    {
       MapPanel.gameObject.SetActive(true);
    }

    public void HideMapPanel()
    {
        MapPanel.gameObject.SetActive(false);
    }
}
