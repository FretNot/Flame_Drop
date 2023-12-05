using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStick : MonoBehaviour
{
    public Transform Player;
    public bool Riding = false;
    public Vector3 player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            Player.transform.SetParent(this.transform);
            Riding = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            Player.transform.SetParent(null);
            Riding = false;
        }
    }
    /*private void Update()
    {
        bool moving = this.GetComponent<Moving_Platform>().moving;

        if (Riding == true)
        {
            if (moving == true)
            {
                float PlayerHeight = Player.GetComponent<CapsuleCollider>().height / 2;
                Vector3 player = new Vector3(this.transform.position.x, this.transform.position.y + PlayerHeight, this.transform.position.z);
                Player.transform.position = player;
            }
        }
        if (Riding == false)
        {
            return;
        }
    }
    */
}
