using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    
    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        BombAction.onPressKey += Explosion;
    }

    private void Explosion(GameObject bomb, float radius)
    {
        float xBomb = bomb.transform.position.x;
        float yBomb = bomb.transform.position.y;
        float zBomb = bomb.transform.position.z;
            
        float xEnemy = transform.position.x;
        float yEnemy = transform.position.y;
        float zEnemy = transform.position.z;
            
        //distance = Mathf.Sqrt(Mathf.Pow(xBomb - xEnemy, 2) + Mathf.Pow(zBomb - zEnemy, 2));
        distance = new Vector3(xBomb - xEnemy,yBomb - yEnemy, zBomb - zEnemy).magnitude;

        if (distance <= radius)
        { 
            Destroy(gameObject);
            BombAction.onPressKey -= Explosion;
        }
    }
}
