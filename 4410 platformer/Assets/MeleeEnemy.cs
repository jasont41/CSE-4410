using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyController
{
    public override void Damage(float amt)
    {
        hp -= amt;
        if (hp <= 0) Die(); 
    }
    public override void Die()
    {
        gameObject.SetActive(false); 
    }
    public override void Chase()
    {
        
    }
    public override void Move()
    {
        distance = Vector2.Distance(transform.position, transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * direction * rayLength,wallLayer);
        if (hit.collider != null)
        {
            direction *= -1; 
        }
        if (distance <= chaseRange)
        {
            currentState = enemyStates.chase; 
        }
        bod.AddForce(Vector2.right * direction * spd); 
    }
    public override void Attack()
    {

    }
}
