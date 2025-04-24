using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : SingleBehaviour<GameManager>
{
    public int score;

    public int Score {  get { return score; } set { score = value; OnScoreChange?.Invoke(Score); } }
    private int hiScore;
    public int HiScore { get { return hiScore; } }

    public event Action<int> OnScoreChange;

    public bool gameOver;
    private void Awake()
    {
        gameOver = false;
        hiScore = 0;
        score = 0;
    }


    private void HiScoreBoard(int score)
    {
        if (score >= hiScore)
        {
            hiScore = score;
        }
    }
    public void GameOver()
    {
        gameOver = true;
    }

}
