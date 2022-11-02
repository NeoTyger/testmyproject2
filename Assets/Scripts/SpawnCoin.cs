using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private GameObject coinPreFab;

    private int xMin = -5;
    private int xMax = 20;
    private int zMin = 17;
    private int zMax = 35;
    private int yInicial = 9;

    private void Start()
    {
        SpawnNewCoin();
    }

    public void SpawnNewCoin()
    {
        int xOffset = Random.Range(xMin, xMax);
        int zOffset = Random.Range(zMin, zMax); 
        Vector3 offset = new Vector3(xOffset,yInicial, zOffset); 
        Instantiate(coinPreFab, offset, Quaternion.identity);
    }
}
