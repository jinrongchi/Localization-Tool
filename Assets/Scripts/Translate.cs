using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Translate : MonoBehaviour
{
    Localization languages;
    public GameObject LanguageToggle;
    public Transform ToggleGroup;
    [SerializeField] List<Toggle> toggles;
    [SerializeField] List<Text> textList;

    void Awake()
    {
        languages = Resources.Load<Localization>("Localization");
        foreach (var item in languages.LanguageList)
        {
            GameObject go = GameObject.Instantiate(LanguageToggle);
            go.GetComponent<Toggle>().group = ToggleGroup.GetComponent<ToggleGroup>();
            go.transform.SetParent(ToggleGroup);
            go.transform.GetChild(1).GetComponent<Text>().text = item.LanguageName;
            toggles.Add(go.GetComponent<Toggle>());
        }

        for (int i = 0; i < toggles.Count; i++)
        {
            int id = i;
            toggles[i].onValueChanged.AddListener((bool value) => OnToggleClick(id, value));
        }
        toggles[0].isOn = true;
    }

    void Start()
    {
        OnToggleClick(0, true);
    }

    void OnToggleClick(int id, bool value)
    {
        if (value)
        {
            //Debug.Log(id.ToString() + ":" + value);
            for (int i = 0; i < textList.Count; i++)
            {
                if (languages.LanguageList[id].ContentList.Count>i)
                {
                    textList[i].text = languages.LanguageList[id].ContentList[i];
                }
                else
                {
                    textList[i].text = "";
                }
               
            }
        }
    }
}
