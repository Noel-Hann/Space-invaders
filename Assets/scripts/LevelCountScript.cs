using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelCountScript : MonoBehaviour
{
    private string levelString = "Level\n";

    public int level;

    private TextMeshProUGUI _tmp;
    // Start is called before the first frame update
    void Start()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        level = enemyManager.levelNumber;
        string processedLevelString = levelString;
        //string processedLevelNumber = ;
        if (level < 100)
        {
            int formattingInt = 99;
            while (level < formattingInt)
            {
                processedLevelString += "0";
                formattingInt /= 10;
            }
        }

        processedLevelString += level;

        _tmp.text = processedLevelString;
    }
}
