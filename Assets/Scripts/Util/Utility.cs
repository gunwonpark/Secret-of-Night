using System;
using System.IO;
using UnityEngine;

public static class Utility
{
    /// <summary>
    /// Json을 파싱 하여 불러오는 함수 입니다
    /// </summary>
    /// <typeparam name="TLoad">데이터 베이스 이름</typeparam>
    /// <param name="filename"></param>
    /// <returns>파싱된 데이터 베이스</returns>
    public static TLoad LoadJson<TLoad>(string filename, bool IsInResources = true)
    {
        if (IsInResources)
        {
            TextAsset jsonFile = Resources.Load<TextAsset>($"Json/{filename}");
            if (jsonFile != null)
            {
                string json = jsonFile.text;
                return JsonUtility.FromJson<TLoad>(json);
            }
        }
        else
        {
            string data = File.ReadAllText(filename);
            if (data != null)
            {
                return JsonUtility.FromJson<TLoad>(filename);
            }
        }

        Debug.Log($"There is no file {filename}");
        return default;
    }
    public static void SaveToJson<TSave>(TSave data, string jsonDataPath)
    {
        try
        {
            var directory = Path.GetDirectoryName(jsonDataPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonUtility.ToJson(data);
            File.WriteAllText(jsonDataPath, json);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to save data: {ex.Message}");
        }
    }
    public static void DeleteJson(string jsonDataPath)
    {
        File.Delete(jsonDataPath);
    }
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null) return null;

        if (recursive)
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (component.name == name)
                {
                    return component;
                }
            }
        }
        else
        {
            Transform transform = go.transform.Find(name);
            if (transform != null)
            {
                return transform.GetComponent<T>();
            }
        }
        return null;
    }
    // GameObject는 Copmonent가 아니기 때문에
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform != null)
            return transform.gameObject;
        return null;
    }

    //Extension
    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();
        return component;
    }
    public static void BindEvent(this GameObject go, Action action, UIEvent type = UIEvent.Click)
    {
        UIBase.BindEvent(go, action, type);
    }

    public static Vector3 GetRandomPointInCircle(Vector3 center, float radius)//랜덤한 스폰지점
    {
        int maxTries = 10;
        //[todo]랜덤지점에 뭐가 없을때만 반환
        for (int i = 0; i < maxTries; i++)
        {

            float angle = UnityEngine.Random.Range(0f, Mathf.PI * 2f); // 랜덤한 각도 생성
            float distance = Mathf.Sqrt(UnityEngine.Random.Range(0f, 1f)) * radius; // 랜덤한 거리 생성
            float x = center.x + distance * Mathf.Cos(angle); // x 좌표 계산
            float z = center.z + distance * Mathf.Sin(angle); // z 좌표 계산
            Vector3 randomPoint = new Vector3(x, center.y, z); // 랜덤 지점 반환

            //return randomPoint;
            if (IsValidSpot(randomPoint))
            {
                return randomPoint;
            }
        }
        //다른 오브젝트가 있으면 일단 센터포지션 반환
        return center;
    }
    private static bool IsValidSpot(Vector3 point)
    {
        RaycastHit hit;

        //레이로 쏜 곳에 다른 오브젝트가 있으면 false
        if (Physics.Raycast(point, Vector3.down, out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                return true;
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("obstacle"))
            {
                return false;
            }
        }
        return false;
    }
}
