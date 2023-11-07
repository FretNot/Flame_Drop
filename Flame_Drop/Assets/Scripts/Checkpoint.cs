using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public float Lives = 3;
    public GameObject checkPoint;
    Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = gameObject.transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Lives--;
            Debug.Log("You died");
            Respawn();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CheckPoint")
        {
            Destroy(checkPoint);
            checkPoint = other.gameObject;
            spawnPoint = checkPoint.transform.position;
        }
    }

    void Respawn()
    {
        gameObject.transform.position = spawnPoint;
    }
}
