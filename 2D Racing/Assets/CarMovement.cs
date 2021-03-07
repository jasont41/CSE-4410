using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float acceleration;
    public float rotation;
    public float maxSpeed;
    public float currentSpeed; 
    Rigidbody2D bod;
    private void Awake()
    {
        bod = GetComponent<Rigidbody2D>(); 
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            bod.AddForce(Vector2.up * acceleration * Time.deltaTime); 
        }
    }
}
