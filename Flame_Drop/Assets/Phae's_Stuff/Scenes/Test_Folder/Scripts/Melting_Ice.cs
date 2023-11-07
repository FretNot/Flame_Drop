using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melting_Ice : MonoBehaviour
{
    private float x;
    private float y;
    private float z;

   // public float temp;
    //public float ogTemp;

    //public bool whiteHot = false;

    public float waitTimer;

    public void Update()
    {
        //if (temp > ogTemp)
        //{
           // whiteHot = true;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" /*&& whiteHot*/)
        {
            Debug.Log("Shrinks & Disappears");
            StartCoroutine(Shrink());
        }
    }

    IEnumerator Shrink()
    {
        yield return new WaitForSeconds(waitTimer);
        transform.localScale = new Vector3(x - 0.9f, y - 0.9f, z - 0.9f);
        //transform.localScale = new Vector3(x - 0.2f, y - 0.2f, z - 0.2f);
        yield return new WaitForSeconds(waitTimer);
        transform.localScale = new Vector3(x - 0.7f, y - 0.7f, z - 0.7f);
        yield return new WaitForSeconds(waitTimer);
        //transform.localScale = new Vector3(x - 0.4f, y - 0.4f, z - 0.4f);
        transform.localScale = new Vector3(x - 0.4f, y - 0.4f, z - 0.04f);
        yield return new WaitForSeconds(waitTimer);
        Destroy(this.gameObject);
    }
}
