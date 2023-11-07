using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBurn : MonoBehaviour
{
    public GameObject BigThing;
    public GameObject BigBurned;
    public float burnReq;
    public float burnAmount;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Begin MultiBurn");
            burnAmount += 1;
            if (burnAmount == burnReq)
            {
                Instantiate(BigBurned);
                Invoke("Despawn", .1f);
                GameObject.Find("Player").GetComponent<Temp>().temp += 100;
            }
        }
    }
    private void Despawn()
    {
        Destroy(BigThing);
        Destroy(gameObject);
    }
}
