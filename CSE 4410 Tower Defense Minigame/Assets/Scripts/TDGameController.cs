using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TDGameController : MonoBehaviour
{
    public GameObject tower;
    [HideInInspector] public float currentTowerCost;
    public GameObject enemy; 
    public Transform[] waypoints;
    public float maxHP;
    public float hp;
    public Image healthImage;
    public float lerpSpd;
    public Transform spawnPOS; 

    public float money;
    public Text moneyText;

    private IEnumerator coroutine; 
    private void Awake()
    {
        hp = maxHP;
        healthImage.fillAmount = Mathf.Lerp(healthImage.fillAmount, hp / maxHP, lerpSpd * Time.deltaTime);
        UpdateTower(100f);
        coroutine = wave(0.1f, 4);
        StartCoroutine(coroutine);
        coroutine = wave(15f, 6);
        StartCoroutine(coroutine);
        coroutine = wave(15f, 8);
        StartCoroutine(coroutine);
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
        moneyText.text = "Money: " + money.ToString(); 
    }
    public void UpdateTower(float amt)
    {
        currentTowerCost = amt; 
    }
    public void TakeDamage(float amt)
    {
        hp -= amt;
        healthImage.fillAmount = Mathf.Lerp(healthImage.fillAmount, hp / maxHP, lerpSpd * Time.deltaTime);
    }
    public void GiveMoney(float amt)
    {
        money += amt; 
    }
    private IEnumerator wave(float waitTime, int num)
    {
        yield return new WaitForSeconds(waitTime);
            for(int i = 0; i < num; i++)
        {
            Instantiate(enemy, spawnPOS.position, spawnPOS.rotation);
            yield return new WaitForSeconds(2f); 

        }
    }
}
