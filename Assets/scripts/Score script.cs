using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scorescript : MonoBehaviour
{
    public static int score = 0000;
    public string scoreText = "Score\n";
    private TextMeshProUGUI _tmpro;
    

    private void OnEnable()
    {
        Enemy.OnEnemyDestroyed += increaseScore;
        Enemy.OnEnemy2Destroyed += increaseScoreBy20;
        Enemy.OnEnemy3Destroyed += increaseScoreBy30;
        Enemy.OnEnemy4Destroyed += increaseScoreBy40;
        enemyManager.onLevelCleared += increaseScoreBy100;
        Player.onPlayerDied += reactToPlayerDeath;
    }

    // Start is called before the first frame update
    void Start()
    {
        _tmpro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
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

    //all these next methods are seperate because we need to call them with events
    void increaseScore()
    {
        increaseScore(10);
    }

    void increaseScoreBy20()
    {
        increaseScore(20);
    }

    void increaseScoreBy30()
    {
        increaseScore(30);
    }

    void increaseScoreBy40()
    {
        increaseScore(40);
    }
    
    void increaseScoreBy100()
    {
        increaseScore(100);
    }
    void increaseScore(int amount)
    {
        score += amount;
    }

    void reactToPlayerDeath()
    {
        GameObject _switchScene = GameObject.Find("SwitchScene");
        _switchScene.GetComponent<SwitchScenes>().LoadGameScene("Credits");
    }

    private void startNewGame()
    {
        score = 0;
    }
}
