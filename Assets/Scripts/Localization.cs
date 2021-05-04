using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class Localization : ScriptableObject
{
    public static Localization Instance;
    public string title = "Language";
    public List<Language> LanguageList;
    //public int LanguageNum = 3;

    void OnEnable()
    {
        Instance = this;
        if (LanguageList == null)
            LanguageList = new List<Language>();
    }
    public void AddLanguage(Language language)
    {
        language.LanguageID = LanguageList.Count;
        LanguageList.Add(language);
    }
    public void Add(int ID, string content)
    {
        LanguageList[ID].ContentList.Add(content);
    }

    public void Remove(int ID, string content)
    {
        LanguageList[ID].ContentList.Remove(content);
    }

    public void RemoveAt(int ID, int index)
    {
        LanguageList[ID].ContentList.RemoveAt(index);
    }
}

[System.Serializable]
public class Language
{
    public int LanguageID;
    public string LanguageName;
    public List<string> ContentList;
}

public class CreateScriptableObject : Editor
{
    public static void CreateAsset<Type>() where Type : ScriptableObject
    {
        Type item = ScriptableObject.CreateInstance<Type>();

        string root = Application.dataPath + "/Resources";
        if (!Directory.Exists(root))
        {
            Directory.CreateDirectory(root);
        }
        string path = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/" + typeof(Type) + ".asset");

        AssetDatabase.CreateAsset(item, path);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = item;
    }

    [MenuItem("Assets/Create/CreateLocalization")]
    public static void CreateLocalization()
    {
        CreateAsset<Localization>();
    }
}