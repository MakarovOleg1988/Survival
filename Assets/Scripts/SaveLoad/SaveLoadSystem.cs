using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class SaveLoadSystem : MonoBehaviour
{
    public int _killScore;


    public string filePath = "int_variables.xml";

    public void SaveIntVariables()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(IntVariableData));

        IntVariableData data = new IntVariableData();
        data._killScore = _killScore;

        FileStream stream = new FileStream(Application.dataPath + "/" + filePath, FileMode.Create);

        serializer.Serialize(stream, data);
        stream.Close();
    }

    public void LoadIntVariables()
    {
        if (File.Exists(Application.dataPath + "/" + filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(IntVariableData));

            FileStream stream = new FileStream(Application.dataPath + "/" + filePath, FileMode.Open);

            IntVariableData data = (IntVariableData)serializer.Deserialize(stream);

            _killScore = data._killScore;

            stream.Close();
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }
}

public class IntVariableData
{
    public int _killScore;
}