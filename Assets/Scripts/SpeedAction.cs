using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAction : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Sube la velocidad al jugador
            Debug.Log("VELOCIDAD MÁXIMA");
            Destroy(gameObject);
        }
    }
}
