using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequiredBurns : MonoBehaviour
{

    public GameObject Burning_Tree;
    public GameObject ParentBurned;

    void OnCollisionEnter(Collision collision)
    {
        //if colliding with player start spawning burning tree, destroy the obhter object & add burns to the parent object by 1
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Begin Burn");
            Instantiate(Burning_Tree, transform.position, transform.rotation);
            Invoke("Despawn", .1f);
            ParentBurned.GetComponent<ParentBurn>().CurrentBurns += 1;
        }
    }
    private void Despawn()
    {
        Destroy(gameObject);
    }
}
