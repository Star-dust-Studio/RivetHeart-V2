using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestData
{
    public int testAge;
    public string testName;

    public TestData(Data data)
    {
        testAge = data.age;
        testName = data.myName;
    }
}
