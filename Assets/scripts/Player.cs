using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  private Rigidbody2D myRigidBody;

  public Transform shottingOffset;
  public float speed = 5;
  public static bool BulletExists = false;

  private void Start()
  {
    myRigidBody = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space) && !BulletExists)
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");
        BulletExists = true;

        //Destroy(shot, 3f);

      }

      if (Input.GetKey(KeyCode.A))
      {
        myRigidBody.velocity = Vector2.left * speed;
      } else if (Input.GetKey(KeyCode.D))
      {
        myRigidBody.velocity = Vector2.right * speed;
      }
      else
      {
        myRigidBody.velocity = Vector2.zero;
      }

      

    }

    
}
