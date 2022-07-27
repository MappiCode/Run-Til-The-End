using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIController uiController;

    public float difficulty = 1f;
    [SerializeField] private float difficultyIncrease = 1f;

    private Grid grid;
    
    private float score = 0;

    private void Start()
    {
        uiController = GetComponent<UIController>();
        grid = GameObject.FindObjectOfType<Grid>();
    }

    private void Update()
    {
        if (grid != null)
            score = Mathf.Round(grid.transform.position.x * -1);
        uiController.UpdateTextField("ScoreValue", score);
    }

    private void FixedUpdate()
    {
        difficulty += difficultyIncrease * Time.deltaTime;
    }
}
