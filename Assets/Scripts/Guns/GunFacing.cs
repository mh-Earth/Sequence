using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFacing : MonoBehaviour
{

    [SerializeField]
    private Camera playerCamera;

    [HideInInspector] public static float GunHolderX;
    // Moving the gun to the aim in y axis
    void gunFacing(){
        
        GunHolderX = playerCamera.transform.localRotation.eulerAngles.x;
        transform.localRotation = playerCamera.transform.localRotation;
    }


    private void Update() {
        
        gunFacing();

    }

}
