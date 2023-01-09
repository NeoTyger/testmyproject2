using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowsBomb : MonoBehaviour
{
    
    [SerializeField] private float throwForce = 30.0f;
    [SerializeField] private GameObject bombPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ThrowBomb();
        }
    }

    private void ThrowBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation);
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
}
