using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scorescript : MonoBehaviour
{
    public int score = 0000;
    public string scoreText = "Score\n";
    private TextMeshProUGUI _tmpro;

    private void OnEnable()
    {
        Enemy.OnEnemyDestroyed += increaseScore;
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

    void increaseScore()
    {
        score += 10;
    }
}
