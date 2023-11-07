using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class white_hot : MonoBehaviour
{
    bool defaultState = true;
    [SerializeField]
    float thingsBurned;
    [SerializeField]
    float thingsLeftToBurn;
    bool whiteHotUp = false;
    bool waterIsUnSafe = true;
    public float turnUpTemp;
    [SerializeField]
    public float throwSpeed;

    [SerializeField]
    public float reduceTime;

    //returns or is in default state
    public void Default()
    {
        if (thingsLeftToBurn < thingsBurned)
        {
            defaultState = true;
            whiteHotUp = false;
            waterIsUnSafe = true;
        }
        else
        {
            defaultState = false;
            whiteHotUp = true;
            enterWhiteHot();
            waterIsUnSafe = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "ice" && whiteHotUp == true && defaultState == false)
        {
            GetComponent<Melting_Ice>();
        }
    }

    //changes to white hot- lowers cool down
    public void enterWhiteHot()
    {
        if (GetComponent<Ice>().temp_Required > turnUpTemp)
        {
          //float v  = GetComponent<CoolDown>()._nextFireTime - reduceTime;
        }
        else
        {
            //do nothing
        }
    }
}
