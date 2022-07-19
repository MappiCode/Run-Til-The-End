using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Serializable] private struct TextField
    {
        public string name;
        public TextMeshProUGUI text;
    }

    [SerializeField] private TextField[] textFields;


    public void UpdateTextField(string textFieldName, float value)
    {
        TextMeshProUGUI tm = textFields.Where(x => x.name == textFieldName).FirstOrDefault().text;
        if (tm != null)
            tm.text = value.ToString();
        else
            Debug.LogWarning("There is no TextField named " + textFieldName + " in the UIController!");
    }
}
