using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossAttack : MonoBehaviour
{
    public GameObject Player;
    public GameObject Wave;
    public GameObject AttackPointTop;
    public GameObject AttackPointBot;
    public float shotTimer;
    public bool Shooting = false;
    public bool StartShooting = false;
    public bool pat1 = false;
    public bool pat2 = false;
    public bool pat3 = false;
    public List<GameObject> unityGameObjects = new List<GameObject>();


    private void Start()
    {
        StartCoroutine(AttackPattern());
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.transform.localScale /= 2;
            if (pat1 == true)
            {
                //StopCoroutine(AttackPattern());
                GameObject[] waves = GameObject.FindGameObjectsWithTag("wave");
                foreach (GameObject target in waves)
                {
                    GameObject.Destroy(target);
                }
                Invoke("phaseUp1", 1f);
                Debug.Log("start pattern 2");
                //StartCoroutine(AttackPattern());
                Player.gameObject.GetComponent<Checkpoint>().Respawn();
                
                
            }
            if (pat2 == true)
            {
                GameObject[] waves = GameObject.FindGameObjectsWithTag("wave");
                foreach (GameObject target in waves)
                {
                    GameObject.Destroy(target);
                }
                Debug.Log("start pattern 3");
                Invoke("phaseUp2", 1f);
            }
            if (pat3 == true)
            {
                StopCoroutine(AttackPattern());
                GameObject[] waves = GameObject.FindGameObjectsWithTag("wave");
                foreach (GameObject target in waves)
                {
                    GameObject.Destroy(target);
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Destroy(this.gameObject);
            }
        }
    }
    private void phaseUp1()
    {
        pat1 = false;
        pat2 = true;
    }
    private void phaseUp2()
    {
        pat2 = false;
        pat3 = true;
    }
    IEnumerator AttackPattern() // puts a stun on the gun to reduce rate of fire
    {
        while (pat1 == true)
        {
            Instantiate(Wave, AttackPointTop.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Debug.Log("spawn bottom");
            Instantiate(Wave, AttackPointBot.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
        }
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
        while (pat3 == true)
        {
            Instantiate(Wave, AttackPointTop.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Instantiate(Wave, AttackPointBot.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Instantiate(Wave, AttackPointTop.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Instantiate(Wave, AttackPointTop.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Instantiate(Wave, AttackPointBot.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Instantiate(Wave, AttackPointTop.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Instantiate(Wave, AttackPointBot.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Instantiate(Wave, AttackPointBot.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
        }
    }
    /*
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

    IEnumerator AttackPattern3() // puts a stun on the gun to reduce rate of fire
    {
        while (pat3 == true)
        {
            Instantiate(Wave, AttackPointTop.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Instantiate(Wave, AttackPointBot.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Instantiate(Wave, AttackPointTop.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Instantiate(Wave, AttackPointTop.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Instantiate(Wave, AttackPointBot.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Instantiate(Wave, AttackPointTop.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Instantiate(Wave, AttackPointBot.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
            Instantiate(Wave, AttackPointBot.transform.position, Wave.transform.rotation);
            yield return new WaitForSeconds(shotTimer);
        }
    }
    */
}