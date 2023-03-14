using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{

    public delegate void EnemyDestroyed();
    public static event EnemyDestroyed OnEnemyDestroyed;
    public delegate void Enemy2Destroyed();
    public static event Enemy2Destroyed OnEnemy2Destroyed;
    public delegate void Enemy3Destroyed();
    public static event Enemy3Destroyed OnEnemy3Destroyed;
    public delegate void Enemy4Destroyed();
    public static event Enemy4Destroyed OnEnemy4Destroyed;

    public delegate void HitLeftWall();
    public static event HitLeftWall onHitLeftWall;

    public delegate void HitRightWall();

    public static event HitRightWall onHitRightWall;
    
    private Rigidbody2D myRigidBody;

    public GameObject bullet;


    public static bool goingLeft = true;
    // Start is called before the first frame update
    private void Start()
    {
        //GameObject.DontDestroyOnLoad(gameObject);
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        
    }

    private void OnEnable()
    {
        onHitLeftWall += changeDirectionToRight;
        onHitRightWall += changeDirectionToLeft;
        Player.onPlayerDied += refreshField;

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerBullet")
        {
            //these all go through and find the correct tag, and call that event
            Debug.Log("Ouch!");
            if (this.gameObject.CompareTag("Enemy"))
            {
                if (OnEnemyDestroyed != null)
                {
                    OnEnemyDestroyed();
                }
            } else if (this.gameObject.CompareTag("Enemy2"))
            {
                if (OnEnemy2Destroyed != null)
                {
                    OnEnemy2Destroyed();
                }
            }else if (this.gameObject.CompareTag("Enemy3"))
            {
                if (OnEnemy3Destroyed != null)
                {
                    OnEnemy3Destroyed();
                }
            }else if (this.gameObject.CompareTag("Enemy4"))
            {
                if (OnEnemy4Destroyed != null)
                {
                    OnEnemy4Destroyed();
                }
            }
           
            
            Destroy(this.gameObject);
        } else if (collision.gameObject.tag == "LeftWall")
        {
            if (onHitLeftWall != null)
            {
                onHitLeftWall();
            }
        } else if (collision.gameObject.tag == "RightWall")
        {
            if (onHitRightWall != null)
            {
                onHitRightWall();
            }
        }
  
    }

    private void Update()
    {
        if (goingLeft)
        {
            myRigidBody.velocity = Vector2.left * enemyManager.enemySpeed;
        }
        else
        {
            myRigidBody.velocity = Vector2.right * enemyManager.enemySpeed;
        }
        
        //TODO fix this calculation, the more enemies there are the more often it should shoot
        int rng = Random.Range(1, (120 * enemyManager.enemyCount) );
        if (rng == 1)
        {
            shoot();
        }
    }

    private void shoot()
    {
        GameObject shot = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        Destroy(shot,2);
        //Debug.Log("Bang!");
        //BulletExists = true;
    }

    void changeDirectionToRight()
    {
        moveDown();
        goingLeft = false;
    }

    void changeDirectionToLeft()
    {
        moveDown();
        goingLeft = true;
    }

    void moveDown()
    {
        //TODO move down
        Vector3 myPositon = gameObject.transform.position;
        gameObject.transform.position = new Vector3(myPositon.x, myPositon.y - 0.1f, myPositon.z);
    }

    private void OnDestroy()
    {
        onHitLeftWall -= changeDirectionToRight;
        onHitRightWall -= changeDirectionToLeft;
        Player.onPlayerDied -= refreshField;

        
    }

    private void refreshField()
    {
        Destroy(this.gameObject);
    }
}
