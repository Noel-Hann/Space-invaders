using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public delegate void LevelCleared();

    public static event LevelCleared onLevelCleared;
    
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemies;

    public int enemyRows;
    public int enemy2Rows;
    public int enemy3Rows;
    public int enemy4Rows;
    
    public int enemyColumns;
    public float enemySpacing = 2.5f;
    public static int enemyCount = 0;
    public static float enemySpeed = 5f;
    public static int levelNumber = 1;

    public int remainingEnemies;
    
    // Start is called before the first frame update

    void OnEnable()
    {
        Enemy.OnEnemyDestroyed += decrimentEnemies;
        Enemy.OnEnemy2Destroyed += decrimentEnemies;
        Enemy.OnEnemy3Destroyed += decrimentEnemies;
        Enemy.OnEnemy4Destroyed += decrimentEnemies;
        onLevelCleared += nextLevel;
        Player.onPlayerDied += newGame;
    }
    void Start()
    {
        //Debug.Log("Entered start function");
        //enemySpeed = 5;//we now do this in instantiateEnemies
        instantiateEnemies();
        //Instantiate(enemy, enemies.transform.position,Quaternion.identity,enemies.transform);
    }

    // Update is called once per frame
    void Update()
    {
        remainingEnemies = enemyCount;
    }

    public void instantiateEnemies()
    {
        enemyCount = 0;
        enemySpeed = 5 + levelNumber;
        for (int i = 0; i < enemyColumns; i++)
        {
            int totalColumns = 0;
            //Debug.Log("entered outer loop");
            for (int j = 0; j < enemy4Rows; j++)
            {
                //Debug.Log("Entered inner loop");
                Vector3 position = new Vector3(i * enemySpacing, totalColumns * enemySpacing, 0.1f);//otherwise it wont stick out for some reason
                position = enemies.transform.position - position;
                Instantiate(enemy4, position, Quaternion.identity,enemies.transform);
                enemyCount++;
                //Debug.Log($"Instantiated enemy at {position}");
                totalColumns++;
            }
            for (int j = 0; j < enemy3Rows; j++)
            {
                //Debug.Log("Entered inner loop");
                Vector3 position = new Vector3(i * enemySpacing, totalColumns * enemySpacing, 0);
                position = enemies.transform.position - position;
                Instantiate(enemy3, position, Quaternion.identity,enemies.transform);
                enemyCount++;
                totalColumns++;
                //Debug.Log($"Instantiated enemy at {position}");
            }
            for (int j = 0; j < enemy2Rows; j++)
            {
                //Debug.Log("Entered inner loop");
                Vector3 position = new Vector3(i * enemySpacing, totalColumns * enemySpacing, 0);
                position = enemies.transform.position - position;
                Instantiate(enemy2, position, Quaternion.identity,enemies.transform);
                enemyCount++;
                totalColumns++;
                //Debug.Log($"Instantiated enemy at {position}");
            }
            for (int j = 0; j < enemyRows; j++)
            {
                //Debug.Log("Entered inner loop");
                Vector3 position = new Vector3(i * enemySpacing, totalColumns * enemySpacing, 0);
                position = enemies.transform.position - position;
                Instantiate(enemy, position, Quaternion.identity,enemies.transform);
                enemyCount++;
                totalColumns++;
                //Debug.Log($"Instantiated enemy at {position}");
            }
        } 
    }

    public void decrimentEnemies()
    {
        enemyCount--;

        if (enemyCount <= 5)
        {
            enemySpeed = 8 + levelNumber;
        } else if(enemyCount <= 10)

        {
            enemySpeed = 7 + levelNumber;
        } else if (enemyCount <= 15)
        {
            enemySpeed = 6 + levelNumber;
        }

        if (enemyCount == 0)
        {
            if (onLevelCleared != null)
            {
                onLevelCleared();
            }
        }
        //Debug.Log($"There are {enemyCount} enemies left");
    }

    public void nextLevel()
    {
        levelNumber++;
        instantiateEnemies();
    }

    public void newGame()
    {
        levelNumber = 1;
        instantiateEnemies();
    }

    
}
