using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreManager : MonoBehaviour
{
    public int p1Score;
    public int p2Score;
    public Text p1;
    public Text p2;

    private void Update()
    {
        p1.text = p1Score.ToString();
        p2.text = p2Score.ToString(); 
    }
}
