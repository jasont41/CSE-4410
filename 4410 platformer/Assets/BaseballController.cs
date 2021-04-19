﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballController : MonoBehaviour
{
    public float spd;
    Rigidbody2D bod;
    public float damage = 1;
    bool hasHurt;

    private void Awake()
    {
        bod = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        hasHurt = false;
        bod.AddForce(transform.up * spd);

        Invoke("Disable", 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasHurt)
        {
            collision.GetComponent<PlayerController>().Damage(damage);
            hasHurt = true;
            Invoke("Disable", 0.001f);
        }
        if (collision.CompareTag("Wall"))
        {
            Invoke("Disable", 0.001f);
        }
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}