using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public enum Panels { PreGame, InGame, EndScreen};

    [Serializable] private struct TextField
    {
        public string name;
        public TextMeshProUGUI text;
    }

    [SerializeField] private TextField[] textFields;
    [SerializeField] private GameObject[] uiPanels;

    public GameObject activePanel { get; private set; }

    private void Start()
    {
        SetActivePanel(Panels.PreGame);
    }

    public void UpdateTextField(string textFieldName, float value)
    {
        TextMeshProUGUI tm = textFields.Where(x => x.name == textFieldName).FirstOrDefault().text;
        if (tm != null)
            tm.text = value.ToString();
        else
            Debug.LogWarning("There is no TextField named " + textFieldName + " in the UIController!");
    }

    public void SetActivePanel(Panels panel)
    {
        activePanel = uiPanels[((int)panel)];

        foreach (var uiPanel in uiPanels)
        {
            if (uiPanel.name == panel.ToString())
                uiPanel.SetActive(true);
            else 
                uiPanel.SetActive(false);
        }
    }

    private void PlayerHit()
    {
        SetActivePanel(Panels.EndScreen);
    }
}
