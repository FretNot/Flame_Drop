using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossPattern2 : BossAttack
{
    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (pat1 == true)
            {
                StopCoroutine(AttackPattern1());
                GameObject[] waves = GameObject.FindGameObjectsWithTag("wave");
                foreach (GameObject target in waves)
                {
                    GameObject.Destroy(target);
                }
                Invoke("phaseUp1", 1f);
                Debug.Log("start pattern 2");
                StartCoroutine(AttackPattern2());
                Player.gameObject.GetComponent<Checkpoint>().Respawn();


            }
            if (pat2 == true)
            {
                StopCoroutine(AttackPattern2());
                GameObject[] waves = GameObject.FindGameObjectsWithTag("wave");
                foreach (GameObject target in waves)
                {
                    GameObject.Destroy(target);
                }
                Debug.Log("start pattern 3");
                Invoke("phaseUp2", 1f);
                StartCoroutine(AttackPattern3());
            }
        }
    }
    IEnumerator AttackPattern2() // puts a stun on the gun to reduce rate of fire
    {
        while (pat2 == true)
        {
            Instantiate(Wave, AttackPointTop.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Instantiate(Wave, AttackPointTop.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Debug.Log("spawn bottom");
            Instantiate(Wave, AttackPointBot.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Instantiate(Wave, AttackPointBot.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
        }
    }
    */
}
