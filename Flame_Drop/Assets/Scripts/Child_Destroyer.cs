using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child_Destroyer : MonoBehaviour
{
    public GameObject Child;

    void OnCollisionEnter(Collision collision)
    {
        //on collision destroys the childed object
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Begone Child");
            Destroy(Child);
        }
    }
}
