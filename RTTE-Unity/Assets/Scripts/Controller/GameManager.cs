using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIController uiController;
    public AnimController animController;

    public float difficulty = 1f;
    [SerializeField] private float difficultyIncrease = 1f;

    private Grid grid;
    
    private float score = 0;
    private float highScore;


    private bool _gameIsPaused;
    public bool gameIsPaused
    {
        get { return _gameIsPaused; }
        set { _gameIsPaused = value; }
    }

    private void Start()
    {
        gameIsPaused = true;

        uiController = GetComponent<UIController>();
        animController = GetComponent<AnimController>();
        grid = GameObject.FindObjectOfType<Grid>();
    }


    private void FixedUpdate()
    {
        // Increase Score
        if (grid != null)
            score = Mathf.Round(grid.transform.position.x * -1);
        uiController.UpdateTextField("ScoreValue", score);

        difficulty += difficultyIncrease * Time.deltaTime;
    }


    private void StartGame()
    {
        gameIsPaused = false;
        uiController.SetActivePanel(UIController.Panels.InGame);
        animController.ActivateAnimator("player");
    }

    // Used in Restart-Button on EndScreen
    public void RestartGame()
    {
        SceneController.ReloadScene();
    }

    private void PlayerHit()
    {
        gameIsPaused = true;

        // Load HighScore
        highScore = SaveSystem.LoadScore().score;
        
        if (score > highScore)
        {
            SaveSystem.SaveScore(score);
            highScore = score;
        }

        uiController.UpdateTextField("EndScoreValue", score);
        uiController.UpdateTextField("HighScoreValue", highScore);

        animController.DeactivadeAnimator("player");
    }

    private void OnAccept()
    {
        if (uiController.activePanel.name == UIController.Panels.PreGame.ToString())
        {
            StartGame();
        }
    }
}
