using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BombAction : MonoBehaviour
{

    private List<GameObject> enemyList = new List<GameObject>();

    private float distance;
    private float radius;

    private GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        bomb = gameObject;
        enemyList.Add(GameObject.FindGameObjectWithTag("Enemy"));
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
            radius = 25f;
            
            if (distance <= radius)
            {
                Destroy(enemy);
            }
        }
    }
}
