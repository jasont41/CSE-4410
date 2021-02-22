using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPaddleController : MonoBehaviour
{
    public bool p1;
    public float spd; 
    Rigidbody2D bod;
    public GameObject gameCon;
    ScoreManager scoring;
    private void Awake()
    {
        scoring = gameCon.GetComponent<ScoreManager>(); 
        
        bod = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (p1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                bod.AddForce(Vector2.up * spd * Time.deltaTime); 
            }
            if (Input.GetKey(KeyCode.S))
            {
                bod.AddForce(-Vector2.up * spd * Time.deltaTime);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                bod.AddForce(Vector2.up * spd * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                bod.AddForce(-Vector2.up * spd * Time.deltaTime);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if(p1 == true)
            {
                scoring.p1Score++; 
            }
            else
            {
                scoring.p2Score++; 
            }
        }
    }
}

