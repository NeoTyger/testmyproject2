using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAction : MonoBehaviour
{

    //vida del player de la clase PlayerMovement
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Cura al 100% al jugador
            //vidaPlayer = 100
            Debug.Log("VIDA MÁXIMA");
            Destroy(gameObject);
        }
    }
}
