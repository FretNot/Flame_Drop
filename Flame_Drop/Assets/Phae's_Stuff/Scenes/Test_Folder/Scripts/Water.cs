using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public bool whiteHotNot = false;

    [SerializeField]
    public float temp;
    [SerializeField]
    public float turnUpTemp;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "water" && temp > turnUpTemp)
        {
            Destroy(this.gameObject);
        }
    }
}
