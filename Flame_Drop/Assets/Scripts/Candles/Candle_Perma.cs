using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle_Perma : MonoBehaviour
{
    public GameObject Lit;
    public GameObject Platform;
    public bool is_Lit = false;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TeleportBeacon")
        {
            Destroy(collision.collider.gameObject);
            Instantiate(Lit, transform.position, transform.rotation);
            is_Lit = true;
            Platform.GetComponent<MovingPlatform2>().moving = true;
        }
    }
}
