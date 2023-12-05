using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentBurn : MonoBehaviour
{
    public int RequiredBurns;
    public int CurrentBurns;
    public GameObject BurnedVersion;

    public void Start()
    {
        CurrentBurns = 0;
    }
    private void FixedUpdate()
    {
        if (CurrentBurns == RequiredBurns)
        {
            Instantiate(BurnedVersion, transform.position, transform.rotation);
            Invoke("Despawn", .1f);
        }
    }
    private void Despawn()
    {
        GameObject.Find("Player").GetComponent<Temp>().temp += 100;
        Destroy(gameObject);
    }
}
