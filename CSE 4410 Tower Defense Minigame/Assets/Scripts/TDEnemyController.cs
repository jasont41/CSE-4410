﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDEnemyController : MonoBehaviour
{
    Rigidbody2D bod;
    public float spd;
    public float maxHP;
    float hp;
    TDGameController cont; 

    Transform target;
    public float rotSpd;
    int curWaypoint;
    float distance;
    public float dmg; 

    bool canMove = true;
    bool hasHurt = false; 
    private void Awake()
    {
        bod = GetComponent<Rigidbody2D>(); 
        cont = FindObjectOfType<TDGameController>();
    }
    private void OnEnable()
    {
        hp = maxHP;
        curWaypoint = 0;
        hasHurt = false; 
        target = cont.waypoints[curWaypoint]; 
    }
    private void Update()
    {
        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotSpd);

        if(canMove) bod.AddForce(transform.up * spd * Time.deltaTime);

        distance = Vector2.Distance(transform.position, target.position); 
        if(distance <= 0.1f)
        {
            if(curWaypoint < cont.waypoints.Length - 1)
            {
                canMove = false;
                Invoke("CanMove", 1f); 
                curWaypoint++;
                target = cont.waypoints[curWaypoint]; 
            }
            else
            {
                if (!hasHurt)
                {
                    cont.TakeDamage(dmg);
                    hasHurt = true; 
                }
                gameObject.SetActive(false); 
            }
        }
    }
    void CanMove()
    {
        canMove = true; 
    }
    public void TakeDamage(float amt)
    {
        hp -= amt; 
        if(hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
