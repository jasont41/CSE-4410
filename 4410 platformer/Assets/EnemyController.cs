using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    public float maxHP;
    protected float hp;
    public float spd;
    public float runSpd;
    public Image healthImage;
    public float chaseRange;
    public float attackRange;
    public enum enemyStates {move, chase, attack};
    public enemyStates currentState = enemyStates.move;

    protected Rigidbody2D bod;
    public LayerMask wallLayer;
    public float rayLength;
    public int direction;
    protected SpriteRenderer rend;
    protected float distance;
    protected PlayerController player; 
    private void Awake()
    {
        bod = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerController>(); 
    }
    private void OnEnable()
    {
        hp = maxHP;
        direction = (Random.value > 0.5f) ? 1 : -1;
    }
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * direction * rayLength);
        rend.flipX = (direction == -1); 
        switch (currentState)
        {
            case enemyStates.move:
                Move();
                break;
            case enemyStates.chase:
                Chase();
                break;
            case enemyStates.attack:
                Attack();
                break;
        }
        healthImage.fillAmount = Mathf.Lerp(healthImage.fillAmount, hp / maxHP, 10 * Time.deltaTime);
        Debug.DrawRay(transform.position, Vector2.right * direction * rayLength);
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                direction *= -1; 
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                Damage(5f); 
            }
        }
    }
    private void LateUpdate()
    {
        healthImage.gameObject.transform.rotation = Quaternion.identity; 
    }
    public virtual void Move() { }
    public virtual void Chase() { }
    public virtual void Attack() { }
    public virtual void Damage(float amt) { }
    public virtual void Die() { } 
}
