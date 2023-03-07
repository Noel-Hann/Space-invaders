using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    public int score = 0000;
    public string scoreText = "High Score\n";
    private TextMeshProUGUI _tmpro;

    private void OnEnable()
    {
        //Enemy.OnEnemyDestroyed += increaseScore;
        //enemyManager.onLevelCleared += increaseScoreBy100;
    }

    // Start is called before the first frame update
    void Start()
    {
        _tmpro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Scorescript.score > score)
        {
            setNewHighscore();
        }
        
        string formattedScore = scoreText;
        if (score < 1000)
        {
            int formattingInt = 999;
            while (score < formattingInt)
            {
                formattedScore += "0";
                formattingInt /= 10;
            }
        }
        _tmpro.text = formattedScore + score;
    }

    void setNewHighscore()
    {
        score = Scorescript.score;
    }

    void increaseScore()
    {
        score += 10;
    }

    void increaseScoreBy100()
    {
        score += 100;
    }
}