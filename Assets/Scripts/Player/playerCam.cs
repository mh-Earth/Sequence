using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCam : MonoBehaviour
{
    [SerializeField]
    private float senX;
    [SerializeField]
    private float senY;

    [SerializeField]
    private Transform orienrarion;
    private float yRotation;
    private float xRotation;

    private void Start() {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Update() {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation ,-85f,85f);
        transform.rotation = Quaternion.Euler(xRotation,yRotation,0f);
        orienrarion.rotation = Quaternion.Euler(0f,yRotation,0);

    }


}
