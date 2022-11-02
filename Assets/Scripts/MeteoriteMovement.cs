using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteMovement : MonoBehaviour
{
    
    private SpawnMeteorite _spawnMeteorite;
    
    [SerializeField] private Transform playerTransform;
    
    private Vector3 _direction;

    [SerializeField] private float meteoriteSpeed = 0.1f;

    private Rigidbody _meteoriteRigidbody;
    
    private void Start()
    {
        _spawnMeteorite = FindObjectOfType<SpawnMeteorite>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        _direction = playerTransform.position - transform.position;
        //_meteoriteRigidbody.velocity = _direction * meteoriteSpeed;
        Debug.Log("El meteorito " + gameObject.name + " sale a una velocidad de " + _meteoriteRigidbody.velocity + " " + _meteoriteRigidbody.velocity.magnitude);
    }
    
    private void Update()
    {
        //_direction = playerTransform.position - transform.position;
        transform.Translate(_direction * Time.deltaTime * meteoriteSpeed); //este meteoriteSpeed me es necesario aqui?
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        //El meteorito al chocarse contra el jugador o el suelo se pulveriza
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            _spawnMeteorite.spawnNewMeteorite();
        }
    }
}
