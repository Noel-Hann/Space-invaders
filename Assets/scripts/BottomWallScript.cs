using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BottomWallScript : MonoBehaviour
{
    public Rigidbody2D rb;

    public delegate void EnemyBrokeThrough();

    public static event EnemyBrokeThrough onEnemyBrokeThrough;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Enemy") || col.transform.CompareTag("Enemy2") || col.transform.CompareTag("Enemy3") || col.transform.CompareTag("Enemy4"))
        {
            if (onEnemyBrokeThrough != null)
            {
                onEnemyBrokeThrough();
            } 
        }
    }

    
}
