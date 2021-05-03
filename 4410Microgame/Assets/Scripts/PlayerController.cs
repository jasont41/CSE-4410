using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform player;
    public float speed;
    public float maxbound, minbound;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire; 
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); 
        if(player.position.x < minbound && h < 0)
        {
            h = 0; 
        }
        else if(player.position.x > maxbound && h > 0)
        {
            h = 0; 
        }
        player.position += Vector3.right * speed * h; 
    }
    private void Update()
    {
        if(Input.GetKeyDown("space") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); 
        }
    }
}
