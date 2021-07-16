using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Data : MonoBehaviour
{
    public int age;
    public string myName;

    [SerializeField]
    private TextMeshProUGUI prevAge;

    [SerializeField]
    private TextMeshProUGUI prevName;

    private void Start()
    {
        TestData testData = SaveLoad.LoadData();

        age = testData.testAge;
        myName = testData.testName;

        prevAge.text = age.ToString();
        prevName.text = myName;

        Debug.Log(Application.persistentDataPath);
    }

    public void UpdateAge(InputField ageInput)
    {
        age = int.Parse(ageInput.text);
    }

    public void UpdateName(InputField nameInput)
    {
        myName = nameInput.text;
    }

    public void SaveGame()
    {
        SaveLoad.SaveData(this);
    }
}
