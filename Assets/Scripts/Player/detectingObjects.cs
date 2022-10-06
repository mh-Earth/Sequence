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
    public static bool isSlotFull = true;

    void rayCast(){

        RaycastHit ray;
        if(Physics.Raycast(playerCamera.transform.position,playerCamera.transform.forward,out ray,range)){
            Debug.DrawRay(playerCamera.transform.position,playerCamera.transform.forward,Color.red);

            if(Input.GetMouseButtonDown(0)){
                GameObject a = Instantiate(Demo,ray.point,Quaternion.LookRotation(ray.normal));
                Destroy(a,2f);
            }


            // print(ray.point);


        }   

    }


    private void Update() {
        if(!isSlotFull){
            rayCast();

        }

    }
}
