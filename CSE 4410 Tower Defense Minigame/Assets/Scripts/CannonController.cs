using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float shootSpd;
    public float rotSpd;
    public Transform target;
    public float attackRange;
    float cools;
    public GameObject bullet; 
    public void OnEnable()
    {
        GetComponent<CircleCollider2D>().radius = attackRange;
        cools = shootSpd;
    }
    
    private void Update()
    {
        if (target != null){
            Debug.Log(target.gameObject);
        }
        if(target != null){
            Vector3 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotSpd);
            if (cools > 0)
            {
                cools -= Time.deltaTime; 
            }
            if(cools <= 0)
            {
                Shoot();
            }
        }
    }
    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        cools = shootSpd; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && target == null)
        {
            target = collision.transform;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && target == null)
        {
            target = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && target == collision.transform)
        {
            target = null;
        }
    }
}
