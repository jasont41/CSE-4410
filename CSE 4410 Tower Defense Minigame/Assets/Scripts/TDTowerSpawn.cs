using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDTowerSpawn : MonoBehaviour
{
    TDGameController cont;
    private void Awake()
    {
        cont = FindObjectOfType<TDGameController>(); 
    }
    private void OnMouseDown()
    { 
        Instantiate(cont.tower, transform.position, transform.rotation);
        gameObject.SetActive(false); 
    }
}
