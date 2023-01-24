using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAction : ItemAction
{

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    //vida del player de la clase PlayerMovement
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Cura al 100% al jugador
            //vidaPlayer = 100
            _gameManager.playerHealth = 100.0f;
            _gameManager._healthBar.value = _gameManager.playerHealth; 
            ItemMsg();
            Destroy(gameObject);
        }
    }

    public override void ItemMsg()
    {
        Debug.Log("VIDA MÁXIMA!!!");
    }
}
