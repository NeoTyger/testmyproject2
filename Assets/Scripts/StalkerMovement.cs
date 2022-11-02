using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    
    private Vector3 direccion;
    
    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }
    
    private void Update()
    {
        direccion = playerTransform.position - transform.position;
        transform.Translate(direccion * Time.deltaTime);
    }
}
