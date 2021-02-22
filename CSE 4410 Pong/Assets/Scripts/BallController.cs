using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class BallController : MonoBehaviour
{
    Rigidbody2D bod;
    public float spd;
    public float randomUp; 
    private void Awake()
    {
        bod = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        int dir = Random.Range(0, 2); 
        if(dir == 0)
        {
            bod.AddForce(Vector2.right * spd); 
        }
        else
        {
            bod.AddForce(Vector2.right * -spd);
        }
        bod.AddForce(Vector2.up * Random.Range(-randomUp, randomUp));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("test");
            Vector2 vel;
            vel.x = bod.velocity.x;
            vel.y = (bod.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            bod.velocity = vel;
        }
        if (collision.gameObject.CompareTag("death"))
        {
            Debug.Log("test");
            SceneManager.LoadScene("Dead"); 
        }
    }
}
