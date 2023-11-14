using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melting_Ice : MonoBehaviour
{
    private float x;
    private float y;
    private float z;

    [SerializeField]
    public float waitTimer;

    private void OnCollisionEnter(Collision collision)
    {
        //if the player collides with this object & their temp is above the melting point then they start the coroutine
        if (collision.gameObject.tag == "player")
        { 
           Debug.Log("Shrinks & Disappears");
            StartCoroutine(Shrink());
        }
    }

    IEnumerator Shrink()
    {
        //waits a time before reducing the size of the object
        //then destroys the object
        yield return new WaitForSeconds(waitTimer);
        transform.localScale = new Vector3(x - 0.99f, y - 0.99f, z - 0.99f);
        yield return new WaitForSeconds(waitTimer);
        transform.localScale = new Vector3(x - 0.3f, y - 0.3f, z - 0.3f);
        yield return new WaitForSeconds(waitTimer);
        transform.localScale = new Vector3(x - 0.2f, y - 0.2f, z - 0.2f);
        yield return new WaitForSeconds(waitTimer);
        Destroy(this.gameObject);
    }
}
