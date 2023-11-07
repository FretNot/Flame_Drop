using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBeacon : MonoBehaviour
{

    public new Camera camera;
    public GameObject teleportBeacon;
    public GameObject currentBeacon;
    public Transform firePoint;
    public float grenadeThrowForce;
    private bool grenadeOut = false;
    //bool readyToHop;
    //bool fireOut = false;

    [Header("Settings")]
    public int totalHops;

    public CoolDown _cooldown;
    /*
        private static TeleportBeacon _instance;

        public static TeleportBeacon Instance
        {
            get { return _instance; }
        }
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }
    */
    //[Header("Settings")]
    //public float hopCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //beGoneSpawn();
        //OnMouseExit();
        sendIt();
        //beGoneSpawn();
        teleportNow();
        //beGoneSpawn();
    }

    /*private void beGoneSpawn()
    {
        if (gameObject.tag == "TeleportBeacon")
        {
            //OnMouseOver();
            //OnMouseUpAsButton();
            //OnMouseExit();
            //GetComponent<GameObject>();
            Destroy(currentBeacon);
            currentBeacon = null;
            grenadeOut = false;
            fireOut = false;
            readyToHop = false;
        }
    }*/

   /* public void justDelete()
    {
       
                Destroy(currentBeacon);
                currentBeacon = null;
                grenadeOut = false;
                fireOut = false;
                readyToHop = false;
    }*/

    private void sendIt()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("cooldown: "+ _cooldown.IsCoolingDown);
            if (_cooldown.IsCoolingDown) return;
            if (!grenadeOut)
            {
                //create new
                currentBeacon = Instantiate(teleportBeacon, firePoint.position, Quaternion.identity) as GameObject;
                currentBeacon.GetComponent<Rigidbody>().AddForce(camera.transform.forward * grenadeThrowForce, ForceMode.Impulse);
                
                grenadeOut = true;
                //fireOut = true;
            }
            /*StartCoroutine(waitForIt());

            //is it out?
            if (grenadeOut)
            {
                //move there
                float teleportOffset = GetComponent<CapsuleCollider>().height / 2;
                Vector3 grenadePosition = currentBeacon.transform.position;
                Vector3 teleportLocation = new Vector3(grenadePosition.x, grenadePosition.y + teleportOffset, grenadePosition.z);
                transform.position = teleportLocation;
                Destroy(currentBeacon);
                currentBeacon = null;
                grenadeOut = false;
            }*/
            _cooldown.StartCoolDown();
            if (grenadeOut)
            {
                Destroy(currentBeacon);
                currentBeacon = null;
                currentBeacon = Instantiate(teleportBeacon, firePoint.position, Quaternion.identity) as GameObject;
                currentBeacon.GetComponent<Rigidbody>().AddForce(camera.transform.forward * grenadeThrowForce, ForceMode.Impulse);

                grenadeOut = true;
                //fireOut = true;
            }
        }
    }

   /* private void OnMouseOver()
    {
        GetComponent<GameObject>();
        Destroy(currentBeacon);
        currentBeacon = null;
        grenadeOut = false;
        fireOut = false;
        readyToHop = false;
    }*/

    

   /* private void OnMouseUpAsButton()
    {
        GetComponent<GameObject>();
        Destroy(currentBeacon);
        currentBeacon = null;
        grenadeOut = false;
        fireOut = false;
        readyToHop = false;
    }*/

    /*private void OnMouseExit()
    {
        GetComponent<GameObject>();
        Destroy(currentBeacon);
        currentBeacon = null;
        grenadeOut = false;
        fireOut = false;
        readyToHop = false;
    }*/

    private void teleportNow()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //is it out?
            if (grenadeOut)
            {
                //move there
                float teleportOffset = GetComponent<CapsuleCollider>().height / 2;
                Vector3 grenadePosition = currentBeacon.transform.position;
                Vector3 teleportLocation = new Vector3(grenadePosition.x, grenadePosition.y + teleportOffset, grenadePosition.z);
                transform.position = teleportLocation;
                Destroy(currentBeacon);
                currentBeacon = null;
                grenadeOut = false;
                //fireOut = false;
                //readyToHop = false;
            }
            if (!grenadeOut)
            {
                return;
            }
            //implement hopCoolDown
            //Invoke(nameof(resetHop), hopCoolDown);
            //_cooldown.StartCoolDown();
        }
    }


    /*private void resetHop()
    {
        readyToHop = true;
    }*/
}
