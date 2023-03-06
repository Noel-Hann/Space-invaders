using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public delegate void EnemyDestroyed();
    public static event EnemyDestroyed OnEnemyDestroyed;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("Ouch!");
      if (OnEnemyDestroyed != null)
      {
          OnEnemyDestroyed();
      }
      
      Destroy(this.gameObject);
    }
    
    
}
