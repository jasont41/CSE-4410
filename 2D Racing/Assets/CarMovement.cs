using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CarMovement : MonoBehaviour
{
    public float acceleration;
    public float turnSpeed; 
    public float rotation;
    public float maxSpeed;
    public float currentSpeed;
    public float steeringInput;
    public float speedInput;
    public float speed;
    public bool freezeMovement;
    public bool timeStarted; 
    public Text text;
    public bool halfwayCheck;
    public float finalTime; 
    Rigidbody2D bod;
    private IEnumerator coroutine;

    public Button start;
    public Button Restart;
    public Button MainMenu; 

    //timing variables
    private float startTime; 
    private void Awake()
    {
        Restart.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false); 
        halfwayCheck = false;
        text.text = " "; 
        bod = GetComponent<Rigidbody2D>();
        freezeMovement = false;
        timeStarted = false; 
    }
    private void Update()
    {
        if (freezeMovement == true)
        {
            speedInput = Input.GetAxis("Vertical");
            steeringInput = Input.GetAxis("Horizontal");

            bod.AddForce(transform.up * acceleration * Time.deltaTime * speedInput);
            transform.Rotate(0, 0, turnSpeed * steeringInput * Time.deltaTime);
        }
        if (timeStarted) {
            startTime += Time.deltaTime;
            text.text = startTime.ToString("F2"); 
        }

    }
    public void setBoolTrue()
    {
        start.gameObject.SetActive(false); 
        coroutine = countDown();
        StartCoroutine(coroutine);
        freezeMovement = true;
    }
    public void setBoolFalse()
    {
        freezeMovement = false; 
    }

    private IEnumerator countDown()
    {
        for(int i = 3; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);
            text.text = i.ToString(); 
        }
        text.text = "0:00:00";
        timeStarted = true;
        startTime = 0.0f; 
    }
    public void finishRaceProtocal()
    {
        setBoolFalse();
        finalTime = startTime;
        text.text = finalTime.ToString("2F");
        timeStarted = false;
        Restart.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(true);
    }

    public void restartButton()
    {
        SceneManager.LoadScene("SampleScene"); 
    }
    public void mainMenuButton()
    {
        SceneManager.LoadScene("Title Screen"); 
    }
}
