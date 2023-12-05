using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burned : MonoBehaviour
{

    public GameObject Burning_Tree;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Begin Burn");
            Instantiate(Burning_Tree, transform.position, transform.rotation);
            Invoke("Despawn", .01f);
        }
    }
    private void Despawn()
    {
        Destroy(gameObject);
    }
}