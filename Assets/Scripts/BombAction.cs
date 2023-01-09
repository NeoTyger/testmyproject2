using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{

    private List<GameObject> enemyList;

    private Vector3 distance;
    private Vector3 explosionRadius;

    // Start is called before the first frame update
    void Start()
    {
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
        foreach (var enemy in enemyList)
        {
            distance = transform.position - enemy.transform.position;
            explosionRadius = new Vector3(5,5,5);
            
            if (distance <= explosionRadius)
            {
                Destroy(enemy);
            }
        }
    }
}
