using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{

    private GameManager _gameManager;
    private int coinCount = 0;

    public static event Action onCollectCoin;

    // private void Start()
    // {
    //     _gameManager = FindObjectOfType<GameManager>();
    // }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //add points
            //Debug.Log("+10 pts");
            //_gameManager.IncrementarMonedas();
            if (onCollectCoin != null)
            {
                onCollectCoin();
            }
            Destroy(gameObject);
        }
    }
}
