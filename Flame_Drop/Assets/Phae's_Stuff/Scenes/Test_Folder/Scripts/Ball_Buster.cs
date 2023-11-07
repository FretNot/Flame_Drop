using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Buster : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            Destroy(this.gameObject);
        }
    }
}
