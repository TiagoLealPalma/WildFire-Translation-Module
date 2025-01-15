using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DropdownScript : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public FixedText fixedText;
    public Canvas canvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dropdown.ClearOptions();

        foreach(string lang in Translator.getLanguagesAvailable())
        {
            TMP_Dropdown.OptionData newOption = new TMP_Dropdown.OptionData(lang);
            dropdown.options.Add(newOption);
        }
            dropdown.RefreshShownValue();

            dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int value)
    {   
        // Change language
        Translator.changeLanguage(dropdown.options[value].text);
        Debug.Log("Language changed to " + dropdown.options[value].text);
 
    }

}
