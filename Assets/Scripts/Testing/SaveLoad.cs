using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    public static void SaveData(Data data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Game.savetesting";

        FileStream stream = new FileStream(path, FileMode.Create);

        TestData testData = new TestData(data);

        formatter.Serialize(stream, testData);
        stream.Close();
    }

    public static TestData LoadData()
    {
        string path = Application.persistentDataPath + "/Game.savetesting";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            TestData testData = formatter.Deserialize(stream) as TestData;

            stream.Close();

            return testData;
        }
        else
        {
            Debug.LogError("Error: Save file not found in" + path);
            return null;
        }
    }
}
