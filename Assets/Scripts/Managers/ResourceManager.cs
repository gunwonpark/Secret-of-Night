using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Resources.Load<GameObject>($"{path}");
        if (prefab == null)
        {
            Debug.Log($"There is no prefab in : {path}");
            return null;
        }
        GameObject go = Object.Instantiate(prefab, parent);

        go.name = prefab.name;

        return go;
    }
    public GameObject Instantiate(string path, Vector3 position, Quaternion rotation = default)
    {
        if (rotation == default)
            rotation = Quaternion.identity;
        GameObject prefab = Resources.Load<GameObject>($"{path}");
        if (prefab == null)
        {
            Debug.Log($"There is no prefab in : {path}");
            return null;
        }
        GameObject go = Object.Instantiate(prefab, position, rotation);

        go.name = prefab.name;

        return go;
    }
}
