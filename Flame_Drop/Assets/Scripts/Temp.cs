using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    public float temp;
    private void Start()
    {
        temp = 600;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Burnable")
        {
            temp += 20;
        }
        if (collision.gameObject.tag == "Ice")
        {
            
            if (temp == collision.gameObject.GetComponent<Ice>().temp_Required)
            {
                Destroy(collision.collider.gameObject);
                temp = 600;
            }
        }
    }

}
