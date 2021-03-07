using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 min;
    public Vector2 max;

    private void Start()
    {

    }
    void lateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z); 
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
    }
}
