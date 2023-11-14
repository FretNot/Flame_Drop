using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    public float Lives = 3;

    public GameObject checkPoint;
    Vector3 spawnPoint;

    private void Start()
    {
        //makes the spawnpoint this position & to move player toward
        spawnPoint = gameObject.transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        //if colliding with water subtract a lives & respawn
        if (collision.gameObject.tag == "Water")
        {
            Lives--;
            Debug.Log("You died");
            Respawn();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //if other tag is checkpoint then trigger a destroy the previous checkpoitn & make the new checkpoint the spawn point
        if(other.gameObject.tag == "CheckPoint")
        {
            Destroy(checkPoint);
            checkPoint = other.gameObject;
            spawnPoint = checkPoint.transform.position;
        }
    }

    void Respawn()
    {
        //respawn object to this point
        gameObject.transform.position = spawnPoint;
    }
}
