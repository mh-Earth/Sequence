using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private float gunShootingRange = 50f;
    [SerializeField]
    private GameObject fireParticle;
    private GameObject player;
    private CharacterController characterController;

    public static bool inHand = true;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        characterController = player.GetComponent<CharacterController>();

    }



    void shoot()
    {


        RaycastHit ray;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out ray, gunShootingRange))
        {
            // shoot
            print(GunFacing.GunHolderX);
            if (Input.GetMouseButtonDown(0))
            {
                GameObject a = Instantiate(fireParticle, ray.point, Quaternion.LookRotation(ray.normal));
                Destroy(a, 2f);
            }
        }
    }

    void throwGun()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {




        }


    }







    void Update()
    {
        if (detectingObjects.isSlotFull && inHand)
        {
            shoot();
        }

    }
}
