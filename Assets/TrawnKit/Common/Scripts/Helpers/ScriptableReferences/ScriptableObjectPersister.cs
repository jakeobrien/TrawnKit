using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ScriptableObjectPersister : MonoBehaviour
{

    [SerializeField]
    private List<ScriptableObject> objectsToPersist;

    private void OnEnable()
    {
        foreach (var obj in objectsToPersist)
        {
            var name = GetFilePath(obj);
            if (File.Exists(name))
            {
                var bf = new BinaryFormatter();
                var file = File.Open(name, FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), obj);
                file.Close();
            }
        }
    }

    private void OnDisable()
    {
        foreach (var obj in objectsToPersist)
        {
            var name = GetFilePath(obj);
            var bf = new BinaryFormatter();
            var file = File.Create(name);
            var json = JsonUtility.ToJson(obj);
            bf.Serialize(file, json);
            file.Close();
        }
    }

    private string GetFilePath(ScriptableObject obj)
    {
        return string.Format("{0}/{1}.pso", Application.persistentDataPath, obj.GetInstanceID());
    }

}
