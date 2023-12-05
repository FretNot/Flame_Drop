using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStick : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Platform"))
        {
                m_Rigidbody = GetComponent<Rigidbody>();
                //This locks the RigidBody so that it does not move or rotate in the Z axis.
                m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Platform"))
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            //This locks the RigidBody so that it does not move or rotate in the Z axis.
            m_Rigidbody.constraints =  RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
        }
    }
}
