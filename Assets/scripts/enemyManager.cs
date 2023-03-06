using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    
    
    public GameObject enemy;
    public GameObject enemies;

    public int enemyRows;
    public int enemyColumns;
    public float enemySpacing = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Entered start function");
        instantiateEnemies();
        //Instantiate(enemy, enemies.transform.position,Quaternion.identity,enemies.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instantiateEnemies()
    {
        for (int i = 0; i < enemyRows; i++)
        {
            //Debug.Log("entered outer loop");
            for (int j = 0; j < enemyColumns; j++)
            {
                //Debug.Log("Entered inner loop");
                Vector3 position = new Vector3(i * enemySpacing, j * enemySpacing, 0);
                position = enemies.transform.position - position;
                Instantiate(enemy, position, Quaternion.identity,enemies.transform);
                //Debug.Log($"Instantiated enemy at {position}");
            }
        } 
    }
}
