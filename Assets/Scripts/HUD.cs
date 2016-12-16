using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    private enum UIState
    {
        None,
        Menu,
        Win,
        Lose,
    }

    public GUISkin skin;

    public GameObject player;
    private int score = 0;
    private float gameTime;
    private bool haltGameTime = false;

    private UIState _uiState = UIState.None;

    /// <summary>
    /// Singleton
    /// </summary>
    public static HUD Instance;

    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of HUD!");
        }

        Instance = this;
    }

    void Start()
    {
        Unpause();
        ResetScore();
        ResetGameTime();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(20, Screen.height - 70, 200, 50), GetScore(), skin.label);
        GUI.Label(new Rect(Screen.width - 220, Screen.height - 70, 200, 50), GetGameTime(), skin.label);

        if (_uiState == UIState.Menu)
        {
            // Make a background box
            GUI.Box(new Rect(10, 10, 100, 90), "Game Menu");

            // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
            if (GUI.Button(new Rect(20, 40, 80, 20), "Main menu"))
            {
                GotoMainMenu();
            }

            if (GUI.Button(new Rect(20, 70, 80, 20), "Resume"))
            {
                UnpauseGame();
            }

            // Make the third button.
            if (GUI.Button(new Rect(20, 100, 80, 20), "Quit"))
            {
                Application.Quit();
            }
        }
        else if (_uiState == UIState.Lose)
        {
            // Make a background box
            GUI.Box(new Rect(10, 10, 100, 90), "You Lose!");

            if (GUI.Button(new Rect(20, 40, 80, 20), "Main menu"))
            {
                GotoMainMenu();
            }

            if (GUI.Button(new Rect(20, 70, 80, 20), "Quit"))
            {
                Application.Quit();
            }
        }
        else if (_uiState == UIState.Win)
        {
            GUI.TextArea(new Rect(20, 40, 80, 20), "You win!");

            if (GUI.Button(new Rect(20, 40, 80, 20), "Main menu"))
            {
                GotoMainMenu();
            }

            if (GUI.Button(new Rect(20, 70, 80, 20), "Quit"))
            {
                Application.Quit();
            }
        }
    }

    void Update()
    {
        if (!haltGameTime)
            gameTime += Time.deltaTime;
                
        if (Input.GetKey(KeyCode.Escape))
            PauseGame();
    }

    public void AddToScore(int val)
    {
        score += val;
    }

    public void ResetScore()
    {
        score = 0;
    }

    private string GetScore()
    {
        return score.ToString().PadLeft(8, '0');
    }

    public void HaltGameTime()
    {
        haltGameTime = true;
    }

    public void ResetGameTime()
    {
        gameTime = 0f;
    }


    public void PauseGame()
    {
        Pause();
        _uiState = UIState.Menu;
    }

    public void UnpauseGame()
    {
        Unpause();
        _uiState = UIState.None;
    }

    public void WinGame()
    {
        Pause();
        _uiState = UIState.Win;
    }

    public void LoseGame()
    {
        StartCoroutine(InternalLoseGame());
    }
 
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

    private void Unpause()
    {
        Time.timeScale = 1;
    }

    private string GetGameTime()
    {
        var span = new TimeSpan(0, 0, (int)Math.Floor(gameTime));
        return string.Format("{0:hh\\:mm\\:ss}", span);
    }

    private IEnumerator InternalLoseGame()
    {
        yield return new WaitForSeconds(3);
        Pause();
        _uiState = UIState.Lose;
    }
}

