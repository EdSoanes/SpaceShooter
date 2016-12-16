using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


/// <summary>
/// Creating instance of particles from code with no effort
/// </summary>
public class PlayerScoreHelper : MonoBehaviour
{
    /// <summary>
    /// Singleton
    /// </summary>
    public static PlayerScoreHelper Instance;

    private int score = 0;
    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of PlayerScoreHelper!");
        }

        Instance = this;
        score = 0;
    }

    public void AddToScore(int val)
    {
        score += val;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public string GetScore()
    {
        return score.ToString().PadLeft(8, '0');
    }
}