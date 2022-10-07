// Script for shooting abilities  

using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private float gunShootingRange = 50f;
    [SerializeField]
    private GameObject fireParticle;
    [SerializeField]
    private float fireRate =15f;
    [SerializeField][Range(0.001f,0.005f)]
    private float GunBackForce = 0.002f;

    [SerializeField]
    private float bulletImpactForce = 5f;

    [SerializeField]
    private float gunMaxUplook;
    [SerializeField]
    private float gunMaxDownLook;
    private GameObject player;
    private CharacterController characterController;
    private float nextTimeToFire =0f;
    public static bool inHand = true;
    private Rigidbody rb;
    private GunInfo gunInfo;

    private void Start()
    {   
        gunInfo = GetComponent<GunInfo>();
        player = GameObject.FindGameObjectWithTag("Player");
        characterController = player.GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();

    }

    private void OnEnable() {
        // Looking player up and down clamping in gun up and down clamping
        playerCam.playerUpClamping = gunMaxUplook;
        playerCam.playerDownClamping = gunMaxDownLook;
        //////////////////////////////////////////////////////////////////
        
    }

    

    void shoot()
    {

    
        RaycastHit ray;
        // shoot
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {

                nextTimeToFire = Time.time + 1f/fireRate;
                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out ray, gunShootingRange))
                {   
                    
                    // Fire hit surface particle effects
                    GameObject a = Instantiate(fireParticle, ray.point, Quaternion.LookRotation(ray.normal));
                    Destroy(a, 2f);
                    // Add force to the hit obj
                    if(ray.rigidbody != null){
                        ray.rigidbody.AddForce(-ray.normal*bulletImpactForce,ForceMode.Impulse);

                    }

                    // Gun Back Force
                    // transform.position = new Vector3(0f,0f,GunBackForce);

                }

        }

    }

    void throwGun()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.parent = null;
            rb.AddForce(Vector3.forward * 10,ForceMode.Impulse);




        }


    }



    private void LateUpdate() {
        
        // throwGun();

    }




    void Update()
    {
        // very very very important!!!!!!!!!
        // Soja hate ghi na ber hole jor kore ber korte hy 😤
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(gunInfo.rotation);
        //////////////////////////////////////////////////////////////
        if (detectingObjects.isSlotFull && inHand)
        {   
            shoot();
        }

    }
}
