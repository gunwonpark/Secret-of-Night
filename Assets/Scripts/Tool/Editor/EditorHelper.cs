using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityObject = UnityEngine.Object;

public class EditorHelper
{

    /// <summary>
    /// 경로 계산 함수.
    /// </summary>
    /// <param name="p_clip"></param>
    /// <returns></returns>
    public static string GetPath(UnityEngine.Object p_clip)
    {
        string retString = string.Empty;
        retString = AssetDatabase.GetAssetPath(p_clip);
        string[] path_node = retString.Split('/'); //Assets/9.ResourcesData/Resources/Sound/BGM.wav
        bool findResource = false;
        for (int i = 0; i < path_node.Length - 1; i++)
        {
            if (findResource == false)
            {
                if (path_node[i] == "Resources")
                {
                    findResource = true;
                    retString = string.Empty;
                }
            }
            else
            {
                retString += path_node[i] + "/";
            }

        }

        return retString;
    }

    /// <summary>
    /// Data 리스트를 enum structure로 뽑아주는 함수.
    /// </summary>
    public static void CreateEnumStructure(string enumName, StringBuilder data)
    {
        string templateFilePath = "Assets/Editor/EnumTemplate.txt";

        string entittyTemplate = File.ReadAllText(templateFilePath);

        entittyTemplate = entittyTemplate.Replace("$DATA$", data.ToString());
        entittyTemplate = entittyTemplate.Replace("$ENUM$", enumName);
        string folderPath = "Assets/Scripts/GameData/";
        if (Directory.Exists(folderPath) == false)
        {
            Directory.CreateDirectory(folderPath);
        }

        string FilePath = folderPath + enumName + ".cs";
        if (File.Exists(FilePath))
        {
            File.Delete(FilePath);
        }
        File.WriteAllText(FilePath, entittyTemplate);
    }

    public static void EditorToolTopLayer(BaseData data, ref int selection, ref UnityObject source, int uiWidth)
    {
        EditorGUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("Add", GUILayout.Width(uiWidth)))
            {
                data.AddData("New Data");
                selection = data.GetDataCount() - 1; // 마지막 리스트 넘버
                source = null;
            }
            if (GUILayout.Button("Copy", GUILayout.Width(uiWidth)))
            {
                if (selection >= 0)
                {
                    data.CopyData(selection);
                    source = null;
                    selection = data.GetDataCount() - 1;
                }
            }
            if (data.GetDataCount() > 0)
            {
                if (GUILayout.Button("Remove", GUILayout.Width(uiWidth)))
                {
                    if (selection >= 0)
                    {
                        source = null;
                        data.RemoveData(selection);
                    }
                }
            }
            if (selection > data.GetDataCount() - 1)
            {
                selection = data.GetDataCount() - 1;
            }
        }
        EditorGUILayout.EndHorizontal();
    }
    public static void EditorToolListLayer(ref Vector2 ScrollPosition, BaseData data, ref int selection, ref UnityObject source, int uiWidth)
    {
        EditorGUILayout.BeginVertical(GUILayout.Width(uiWidth));
        {
            EditorGUILayout.Separator();
            EditorGUILayout.BeginVertical("box");
            {
                ScrollPosition = EditorGUILayout.BeginScrollView(ScrollPosition);
                {
                    if (data.GetDataCount() > 0)
                    {
                        int lastSelection = selection;
                        //인덱스가 포함된 스크롤 뷰를 생성
                        selection = GUILayout.SelectionGrid(selection, data.GetNameList(true), 1);

                        if (lastSelection != selection)
                        {
                            source = null;
                        }
                    }
                }
                EditorGUILayout.EndScrollView();
            }
            EditorGUILayout.EndVertical();

        }
        EditorGUILayout.EndVertical();
    }
}
