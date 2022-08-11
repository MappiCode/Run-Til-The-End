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

    public GameObject[] texts;
    public GameObject[] uiPanels;

    public GameObject activePanel { get; private set; }

    private void Start()
    {
        SetActivePanel(Panels.PreGame);
    }

    public void UpdateTextField(string textName, float value)
    {
        TextMeshProUGUI tm = texts.Where(x => x.name == textName).FirstOrDefault().GetComponent<TextMeshProUGUI>();
        if (tm != null)
            tm.text = value.ToString();
        else
            Debug.LogWarning("There is no TextField named " + textName + " in the UIController!");
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

    public void TextAnimation(string tName, AnimatableText.Animations anim)
    {
        AnimatableText aniText = texts.Where(text => text.name == tName).First().GetComponent<AnimatableText>();
        if (aniText != null)
            aniText.activeAnimation = anim;
        else
            Debug.LogWarning("There is no Animatable Text named " + tName + " in the UIController!");
    }

    public void ShowEndscreen()
    {
        SetActivePanel(Panels.EndScreen);
    }
}
