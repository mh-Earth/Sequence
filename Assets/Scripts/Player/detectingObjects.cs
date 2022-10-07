using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectingObjects : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private float range = 100f;
    [SerializeField]
    private GameObject Demo;
    public static bool isSlotFull;

    [SerializeField]
    private GameObject playerGunSlot;
    private Gun gunScripts;
    private GunInfo gunInfo;
    private RaycastHit gunInHand;
    private RaycastHit itemInHand;
    private CharacterController playerController;

    private void Start()
    {

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();

        if (playerGunSlot.transform.childCount <= 0)
        {

            isSlotFull = false;
            return;
        }

        else if (playerGunSlot.transform.childCount == 1)
        {

            isSlotFull = true;

        }

    }


    void resetClamping(){

        playerCam.playerDownClamping = 85;
        playerCam.playerUpClamping = -90;


    }


    // Function for pickup guns
    void pickUpObjects()
    {
        RaycastHit ray;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out ray, range))
        {
            if (Input.GetMouseButtonDown(1))
            {

                // if the object is a gun
                if (ray.rigidbody != null && ray.transform.GetComponent<Gun>() != null && !isSlotFull)
                {
                    ray.transform.SetParent(playerGunSlot.transform);
                    ray.transform.GetComponent<Gun>().enabled = true;
                    gunInfo = ray.transform.GetComponent<GunInfo>();
                    ray.rigidbody.useGravity = false;
                    ray.rigidbody.isKinematic = true;
                    ray.transform.localScale = gunInfo.scale;
                    ray.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    ray.transform.localRotation = Quaternion.Euler(gunInfo.rotation);

                    ray.rigidbody.constraints = RigidbodyConstraints.FreezePosition;
                    ray.rigidbody.freezeRotation = true;
                    // Storing the ray obj in global scope
                    gunInHand = ray;
                    isSlotFull = true;

                }

                // if the obj is not a gun
                else if (ray.rigidbody != null && !isSlotFull)
                {
                    ray.transform.SetParent(playerGunSlot.transform);
                    ray.rigidbody.useGravity = false;
                    ray.rigidbody.isKinematic = true;
                    ray.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    ray.rigidbody.constraints = RigidbodyConstraints.FreezePosition;
                    ray.rigidbody.freezeRotation = true;
                    // Storing the ray obj in global scope
                    itemInHand = ray;
                    isSlotFull = true;

                }

                print(ray.transform.name);
            }
        }
    }


    // Throw in Hand Gun
    void dropGun()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (isSlotFull)
            {

                gunInHand.transform.GetComponent<Gun>().enabled = false;
                gunInHand.rigidbody.velocity = playerController.velocity;
                gunInHand.rigidbody.constraints = RigidbodyConstraints.None;
                gunInHand.rigidbody.useGravity = true;
                gunInHand.rigidbody.constraints = RigidbodyConstraints.None;
                gunInHand.rigidbody.isKinematic = false;
                gunInHand.transform.SetParent(null);
                // Throw the gun or drop the gun
                gunInHand.rigidbody.AddForce(playerCamera.transform.forward * 3, ForceMode.Impulse);
                gunInHand.rigidbody.AddForce(playerCamera.transform.up * 3, ForceMode.Impulse);
                float RandomF = Random.Range(-1f,1f);
                gunInHand.rigidbody.AddTorque(new Vector3(RandomF,RandomF,RandomF) * 5);

                resetClamping();
                isSlotFull = false;
            }

        }
    }








    void rayCast()
    {



    }

    private void FixedUpdate()
    {

        dropGun();

    }


    private void Update()
    {
        if (!isSlotFull)
        {
            pickUpObjects();


        }

    }
}
