using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    
    private GameObject[] enemyList;
    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        BombAction.onPressKey += Explosion;
    }

    private void Explosion(GameObject bomb, float radius)
    {
        foreach (var enemy in enemyList)
        {
            float xBomb = bomb.transform.position.x;
            float zBomb = bomb.transform.position.z;
            
            float xEnemy = transform.position.x;
            float zEnemy = transform.position.z;
            
            distance = Mathf.Sqrt(Mathf.Pow(xBomb - xEnemy, 2) + Mathf.Pow(zBomb - zEnemy, 2));

            if (distance <= radius)
            {
                Destroy(gameObject);
                BombAction.onPressKey -= Explosion;
            }
        }
    }
}
