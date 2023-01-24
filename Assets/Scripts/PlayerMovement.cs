using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private GameManager _gameManager;
    
    public int moveSpeed = 50;

    [SerializeField] private int fuerzaSalto = 4;

    // Catched reference
    private Rigidbody _playerRb;

    private bool isGrounded = true;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Hem colisionat amb " + collision.gameObject.name);
        //if (collision.gameObject.name.Equals("Floor"))
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
        // Se puede hacer lo de coger la moneda así, el cual implica al jugador, o desde la clase CollectCoin, donde se implica a la moneda
        /*if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("10 punts");
            Destroy(collision.gameObject);
        }*/
        
        //Cuando el jugador se choca con un enemigo pierde 10 de vida
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _gameManager.TakeDamage(10.0f);
        }
        
        //Cuando el jugador se choca con un meteorito pierde 30 de vida
        if (collision.gameObject.CompareTag("Meteorite"))
        {
            _gameManager.TakeDamage(30.0f);
        }
        
    }
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) == true && isGrounded) 
        {
            _playerRb = this.gameObject.GetComponent<Rigidbody>();
            _playerRb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            isGrounded = false;
        }
        
        //if (Input.GetKeyDown(KeyCode.Space) == true && transform.position.y <= 1.1f) 
        //{
        //    _playerRb = this.gameObject.GetComponent<Rigidbody>();
        //   _playerRb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        //}
        
        if (Input.GetKey(KeyCode.W) == true)
        {
            // Move forward
            // new Vector3(0,0,1) === Vector3.forward
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // Move backwards
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        
        if (Input.GetKey(KeyCode.A) == true)
        {
            // Move left
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Move right
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }

        float rotationAngle = Input.GetAxis("Mouse X");
        transform.Rotate(0, rotationAngle, 0);
    }
}
