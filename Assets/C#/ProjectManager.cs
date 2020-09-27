using System.IO;
using UnityEngine;

public class ProjectManager<T> : MonoBehaviour
{
    public static void SaveToFile(T name)
    {
        string json = JsonUtility.ToJson(name);

        File.WriteAllText(Application.dataPath + "/saveFile.json", json);
    }

    public static T LoadFromFile()
    {
        return JsonUtility.FromJson<T>(File.ReadAllText(Application.dataPath + "/saveFile.json"));
    }
}
