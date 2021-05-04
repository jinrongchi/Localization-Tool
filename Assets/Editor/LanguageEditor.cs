using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class LanguageEditor : MonoBehaviour
{
    Language language;
    public GameObject LanguageToggle;
    public Transform ToggleGroup;
    public string languageContent;
    public int index;
    public int languageId;
    public string languageName;
    public void AddLanguage()
    {
        GameObject go = GameObject.Instantiate(LanguageToggle);
        go.GetComponent<Toggle>().group = ToggleGroup.GetComponent<ToggleGroup>();
        go.transform.SetParent(ToggleGroup);
        go.transform.GetChild(1).GetComponent<Text>().text = languageName;
        language = new Language();
        language.LanguageName = languageName;
        Localization.Instance.AddLanguage(language);
    }
    public void AddContent()
    {
        Localization.Instance.Add(languageId, languageContent);
    }

    public void EditContent()
    {
        Localization.Instance.LanguageList[languageId].ContentList[index] = languageContent;

    }

    public void RemoveAtContent()
    {
        Localization.Instance.RemoveAt(languageId, index);
    }
}
