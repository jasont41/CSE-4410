using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TDGameController : MonoBehaviour
{
    public GameObject tower;
    public float cost;
    public Transform[] waypoints;
    public float maxHP;
    public float hp;
    public Image healthImage;
    public float lerpSpd; 
    private void Awake()
    {
        hp = maxHP;
        healthImage.fillAmount = Mathf.Lerp(healthImage.fillAmount, hp / maxHP, lerpSpd * Time.deltaTime);
    }
    private void Update()
    {
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Time.timeScale *= 2f; 
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Time.timeScale *= 1f;
            }
        }
    }
    public void TakeDamage(float amt)
    {
        hp -= amt;
        healthImage.fillAmount = Mathf.Lerp(healthImage.fillAmount, hp / maxHP, lerpSpd * Time.deltaTime);
    }
}
