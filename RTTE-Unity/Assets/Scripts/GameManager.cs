using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIController uiController;
    private Grid grid;
    
    private float score = 0;

    private void Start()
    {
        uiController = GetComponent<UIController>();
        grid = GameObject.FindObjectOfType<Grid>();
    }

    private void Update()
    {
        score = Mathf.Round(grid.transform.position.x * -1);
        uiController.UpdateTextField("ScoreValue", score);
    }
}
