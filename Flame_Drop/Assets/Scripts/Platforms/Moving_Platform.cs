using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    public Rigidbody body;

    public Vector3 startPos;
    public Vector3 endPos;
    private Vector3 targetPos;
    public GameObject End;
    public bool moving = false;
    public bool ToEnd = true;
    public float speed;

    void Awake()
    {
        endPos = End.transform.position;
        startPos = transform.position;
        targetPos = endPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("PlatEnd"))
        {
            moving = false;
            transform.position = endPos;
        }
    }

    void FixedUpdate()
    {
        if (moving == true) 
        {
            if (ToEnd == true)
            {
                Vector3 currentPos = transform.position;
                targetPos = endPos;

                Vector3 targetDirection = (targetPos - currentPos).normalized;
                body.MovePosition(currentPos + targetDirection * Time.deltaTime * speed);
            }
            if (ToEnd == false)
            {
                Vector3 currentPos = transform.position;
                targetPos = startPos;

                Vector3 targetDirection = (targetPos - currentPos).normalized;
                body.MovePosition(currentPos + targetDirection * Time.deltaTime * speed);
            }
            
        }
    }
}
