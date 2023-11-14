using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    [SerializeField]
    public float temp;

    private void Start()
    {
        //starting temp
        temp = 600;
    }
    void OnCollisionEnter(Collision collision)
    {
        //if player collides with a burnable object add 20 to temp
        if (collision.gameObject.tag == "Burnable")
        {
            temp += 20;
        }
        //player collides with ice destroy that game object & temp = 600
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
