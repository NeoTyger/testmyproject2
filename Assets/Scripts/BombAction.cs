using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class BombAction : MonoBehaviour
{

    //SENSE DELEGATES O EVENTS
    
    
    /*
    //private List<GameObject> enemyList = new List<GameObject>();
    private GameObject[] enemyList;

    private float distance;
    [SerializeField] private float radius = 25f;

    private GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        bomb = gameObject;
        //enemyList.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Explosion();
        }
    }
    private void Explosion()
    {
        Destroy(gameObject);
        
        foreach (var enemy in enemyList)
        {
            float xBomb = bomb.transform.position.x;
            float zBomb = bomb.transform.position.z;
            
            float xEnemy = enemy.transform.position.x;
            float zEnemy = enemy.transform.position.z;
            
            distance = Mathf.Sqrt(Mathf.Pow(xBomb - xEnemy, 2) + Mathf.Pow(zBomb - zEnemy, 2));

            if (distance <= radius)
            {
                Destroy(enemy);
            }
        }
    }*/
    
    //AMB DELEGATES O EVENTS
    

    [SerializeField] private float radius = 25f;
    public delegate void ActionKey(GameObject bomb, float radius);

    public static event ActionKey onPressKey;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (onPressKey != null)
            {
                onPressKey(gameObject, radius);
            }
            Destroy(gameObject);
        }
    }

}
