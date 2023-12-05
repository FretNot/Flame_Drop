using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle_Temp : MonoBehaviour
{
    public GameObject Platform;
    public GameObject fireball;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("TeleportBeacon"))
        {
            fireball = other.gameObject;

            fireball.transform.position = this.transform.position;
            Platform.GetComponent<Moving_Platform>().moving = true;
            Platform.GetComponent<Moving_Platform>().ToEnd = true;
        }
    }
    private void Update()
    {
        if (fireball == null)
        {
            Platform.GetComponent<Moving_Platform>().ToEnd = false;
        }
    }
}
