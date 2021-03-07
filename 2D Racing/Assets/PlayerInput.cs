using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string turning()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            return "left"; 
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            return "right";
        }
        else return " " ; 
    }
}
