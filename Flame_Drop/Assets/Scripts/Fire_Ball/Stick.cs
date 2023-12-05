using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    private Rigidbody rb;

    private bool targetHit= false;

    private void Awake()
    {
        Debug.Log("rigidbody is now set");
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("About to Hit");
        if (targetHit)
        {
            return;
        }
        else
        {
            Debug.Log("Collided : " + collision.gameObject.name);
            Debug.Log("my rb" + rb.name);

            rb.isKinematic = true;
            Debug.Log("Stuck the Landing");
            targetHit = true;
            //rb.isKinematic = true;
            transform.SetParent(collision.transform);
        }
        
       
    }
}
