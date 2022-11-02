using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnMeteorite : MonoBehaviour
{
    [SerializeField] private GameObject meteoritePreFab;

    private int xMin = -5;
    private int xMax = 20;
    private int zMin = 17;
    private int zMax = 35;
    private int yInicial = 30;

    private int meteoriteCount = 0;

    private float timer = 0f;

    private float meteoriteSpawnFrequency = 3f;

    private void Start()
    {
        spawnNewMeteorite();
    }

    public void spawnNewMeteorite()
    {
        //Crea como maximo 5 meteoritos
        /*if (meteoriteCount < 5) 
        {
            int xOffset = Random.Range(xMin, xMax);
            int zOffset = Random.Range(zMin, zMax);
            Vector3 offset = new Vector3(xOffset,yInicial, zOffset);
            Instantiate(meteoritePreFab, offset, Quaternion.identity);

            Instantiate(meteoritePreFab, transform.position, Quaternion.identity);

            meteoriteCount++;
        }*/
        
        //Va creando meteoritos desde las coordenadas que le he dado
        int xOffset = Random.Range(xMin, xMax);
        int zOffset = Random.Range(zMin, zMax);
        Vector3 offset = new Vector3(xOffset,yInicial, zOffset);
        Instantiate(meteoritePreFab, offset, Quaternion.identity);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > meteoriteSpawnFrequency)
        {
            int xOffset = Random.Range(xMin, xMax);
            int zOffset = Random.Range(zMin, zMax);
            Vector3 offset = new Vector3(xOffset,yInicial, zOffset);
            Instantiate(meteoritePreFab, offset, Quaternion.identity);
            timer = 0f;
        }
        
        //InvokeRepeating
        //Coroutines
    }
}
