using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float speed;
    void Update()
    {
            transform.position += speed * Vector3.left * Time.deltaTime;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject[] waves = GameObject.FindGameObjectsWithTag("wave");
            foreach (GameObject target in waves)
            {
                GameObject.Destroy(target);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("WaveBreaker"))
        {
            Destroy(this.gameObject);
        }
    }
}
