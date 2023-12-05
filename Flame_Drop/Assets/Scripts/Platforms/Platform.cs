using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Rigidbody body;

    public float speed;
    public GameObject end;
    public bool moving = false;
    
    void Update()
    {
        if(moving == true)
        {
            transform.position = end.transform.position;
            moving = false;
        }
        
    }
}
