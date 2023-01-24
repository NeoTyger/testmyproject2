using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpeedAction : ItemAction
{

    private PlayerMovement _playerMovement;
    
    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Sube la velocidad al jugador
            _playerMovement.moveSpeed = 100;
            ItemMsg();
            Destroy(gameObject);
        }
    }

    public override void ItemMsg()
    {
        Debug.Log("VELOCIDAD MÁXIMA!!!");
    }
}
