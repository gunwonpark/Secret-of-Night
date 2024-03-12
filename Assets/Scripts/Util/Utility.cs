using UnityEngine;

public static class Utility
{
    /// <summary>
    /// Json을 파싱 하여 불러오는 함수 입니다
    /// </summary>
    /// <typeparam name="TLoad">데이터 베이스 이름</typeparam>
    /// <param name="filename"></param>
    /// <returns>파싱된 데이터 베이스</returns>
    public static TLoad LoadJson<TLoad>(string filename)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>($"Json/{filename}");
        if (jsonFile != null)
        {
            string json = jsonFile.text;
            return JsonUtility.FromJson<TLoad>(json);
        }
        Debug.Log($"There is no file {filename}");
        return default;
    }
}
