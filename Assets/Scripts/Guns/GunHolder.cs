using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour
{

    [SerializeField]
    private Camera playerCamera;

    // Moving the gun to the aim in y axis
    void gunFacing(){

        transform.localRotation = playerCamera.transform.localRotation;
    }


    private void Update() {
        
        gunFacing();

    }

}
