using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBurn : MonoBehaviour
{
    public GameObject BigThing;
    public GameObject BigBurned;
    [SerializeField]
    public float burnReq;
    [SerializeField]
    public float burnAmount;

    void OnCollisionEnter(Collision collision)
    {
        //on collision with player burn increase by 1 & instantiates object & despawns original object & increase temp by 100
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
        //destroys game object
        Destroy(BigThing);
        Destroy(gameObject);
    }
}
