using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(LanguageEditor))]
public class Custom : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        LanguageEditor language = target as LanguageEditor;
        if (GUILayout.Button("Add at Language"))
        {
            language.AddLanguage();
        }
        if (GUILayout.Button("Add Content"))
        {
            language.AddContent();
        }
        if (GUILayout.Button("Edit Content"))
        {
            language.EditContent();
        }
        if (GUILayout.Button("Remove at Content"))
        {
            language.RemoveAtContent();
        }
    }

}
