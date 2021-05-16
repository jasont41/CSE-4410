using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollider : MonoBehaviour
{
    public CarMovement car;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && car.halfwayCheck == true)
        {
            car.finishRaceProtocal(); 
        }
    }
}
