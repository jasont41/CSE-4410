using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float acceleration;
    public float turnSpeed; 
    public float rotation;
    public float maxSpeed;
    public float currentSpeed;
    public float steeringInput;
    public float speedInput;
    public float speed; 
    Rigidbody2D bod;
    private void Awake()
    {
        bod = GetComponent<Rigidbody2D>(); 
    }
    private void Update()
    {
        speedInput = Input.GetAxis("Vertical");
        steeringInput = Input.GetAxis("Horizontal");

        bod.AddForce(transform.up * acceleration * Time.deltaTime * speedInput);
        transform.Rotate(0, 0, turnSpeed * steeringInput * Time.deltaTime);
    }
}
