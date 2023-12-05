using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBeacon : MonoBehaviour
{

    public new Camera camera;
    public GameObject teleportBeacon;
    public GameObject currentBeacon;
    public Transform firePoint;

    [SerializeField]
    public float fireBallThrowForce;
    private bool fireBallOut = false;
    public bool canThrow = true;

    [SerializeField]
    public float throwCoolDown;
    [SerializeField]
    public float defaultThrowCoolDown;
    [SerializeField]
    public float whiteHotCD;

    [Header("Settings")]
    public int totalHops;


    private void Awake()
    {
        whiteHotCD = throwCoolDown / .05f;
        throwCoolDown = defaultThrowCoolDown;
    }
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        sendIt();
        teleportNow();
    }

    private void sendIt()
    {
        //if you press left button on mouse will throw out a ball to teleport to
        if (Input.GetMouseButtonDown(0))
        {
            if (canThrow == true)
            {
                if (!fireBallOut)
                {
                    //create new
                    currentBeacon = Instantiate(teleportBeacon, firePoint.position, Quaternion.identity) as GameObject;
                    currentBeacon.GetComponent<Rigidbody>().AddForce(camera.transform.forward * fireBallThrowForce, ForceMode.Impulse);

                    fireBallOut = true;
                }

                //is it out?
                if (fireBallOut)
                {
                    //if there is a a beacon out destroy the previous one and make a new one
                    Destroy(currentBeacon);
                    currentBeacon = null;
                    currentBeacon = Instantiate(teleportBeacon, firePoint.position, Quaternion.identity) as GameObject;
                    currentBeacon.GetComponent<Rigidbody>().AddForce(camera.transform.forward * fireBallThrowForce, ForceMode.Impulse);

                    fireBallOut = true;
                }
            }
            canThrow = false;
            //forces cooldown
            Invoke(nameof(throwReset), throwCoolDown);
        }
    }

    private void teleportNow()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //is it out?
            if (fireBallOut)
            {
                //move there
                float teleportOffset = GetComponent<CapsuleCollider>().height / 2;
                Vector3 grenadePosition = currentBeacon.transform.position;
                Vector3 teleportLocation = new Vector3(grenadePosition.x, grenadePosition.y + teleportOffset, grenadePosition.z);
                transform.position = teleportLocation;
                Destroy(currentBeacon);
                currentBeacon = null;
                fireBallOut = false;
            }
            if (!fireBallOut)
            {
                return;
            }
        }
    }

    //resets throw capabilities
    private void throwReset()
    {
        canThrow = true;
    }

    //when colliding
    private void OnCollisionEnter(Collision collision)
    {
        //when hit coal- return cooldown to the full number
        if (collision.gameObject.tag == "coal")
        {
            Debug.Log("coal has been hit");
            throwCoolDown = whiteHotCD;
        }

        //when white hot ends divide by float
        if (collision.gameObject.tag == "WHEnd")
        {
            Debug.Log("white hot has ended");
            throwCoolDown = defaultThrowCoolDown;
        }

        //when hit water & the whitHotCD is higher than the defaultThrowCoolDown destroy the object that has been collided with
        if (collision.gameObject.tag == "water" && whiteHotCD == defaultThrowCoolDown)
        {
            Destroy(this.gameObject);
        }
    }
}
