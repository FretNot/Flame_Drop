using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Help : MonoBehaviour
{
    public GameObject forward_CameraPoint;
    public GameObject backward_CameraPoint;

    //public bool isForward = false;
    public bool isOrigin = true;

    public void Update()
    {
        moveCameraToSeeForward();
        moveCameraToSeeBackward();
    }

    private void moveCameraToSeeForward()
    {
        //if you press left button on mouse will throw out a ball to teleport to
        if (Input.GetKeyDown("w"))
        {
            if (isOrigin == true)
            {
                //transform camera to forward_CameraPoint
                transform.position = forward_CameraPoint.transform.position;
                isOrigin = false;
            }
        }
    }

    private void moveCameraToSeeBackward()
    {
        if (Input.GetKeyDown("s"))
        {
            //is it out?
            if (isOrigin == false)
            {
                //transform camera to backward_CameraPoint
                transform.position = backward_CameraPoint.transform.position;
                isOrigin = true;
            }
        }
    }

}
