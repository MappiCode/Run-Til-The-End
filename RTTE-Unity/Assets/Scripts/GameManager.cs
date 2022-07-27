using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIController uiController;
    public SceneController sceneController;
    
    private Grid grid;
    
    private float score = 0;

    private void Start()
    {
        uiController = GetComponent<UIController>();
        sceneController = GetComponent<SceneController>();
        grid = GameObject.FindObjectOfType<Grid>();
    }

    private void Update()
    {
        if (grid != null)
            score = Mathf.Round(grid.transform.position.x * -1);
        uiController.UpdateTextField("ScoreValue", score);
    }
}
