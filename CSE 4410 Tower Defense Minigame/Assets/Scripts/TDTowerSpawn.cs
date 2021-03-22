using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTowerSpawn : MonoBehaviour
{
    TDGameController cont;
    public  SpriteRenderer rend; 
    private void Awake()
    {
        cont = FindObjectOfType<TDGameController>(); 
    }
    private void OnMouseDown()
    {
        if (cont.money >= cont.currentTowerCost)
        {
            cont.GiveMoney(-cont.currentTowerCost);
            Instantiate(cont.tower, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
    private void OnMouseOver()
    {
        if(cont.money >= cont.currentTowerCost)
        {
            rend.color = Color.green; 
        }
        else
        {
            rend.color = Color.red; 
        }
    }
    private void OnMouseExit()
    {
        rend.color = Color.white; 
    }
}
