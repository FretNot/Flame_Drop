using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentBurn : MonoBehaviour
{
    [SerializeField]
    public int RequiredBurns;
    [SerializeField]
    public int CurrentBurns;
    public GameObject BurnedVersion;

    public void Start()
    {
        //how many things have been burned
        CurrentBurns = 0;
    }
    private void FixedUpdate()
    {
        //if current burns = required then spawn the burned one & delete the other
        if (CurrentBurns == RequiredBurns)
        {
            Instantiate(BurnedVersion, transform.position, transform.rotation);
            Invoke("Despawn", .1f);
        }
    }
    private void Despawn()
    {
        //search for the player & add 100 to the temp & destroy the game object
        GameObject.Find("Player").GetComponent<Temp>().temp += 100;
        Destroy(gameObject);
    }
}
