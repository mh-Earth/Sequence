using UnityEngine;

public class playerCam : MonoBehaviour
{   
    [SerializeField]
    private GameObject playerBody;
    [SerializeField]
    private float senX;
    [SerializeField]
    private float senY;

    [SerializeField]
    private Transform orientation;
    private float yRotation;
    private float xRotation;
    [Header("smoothing")]
    [SerializeField][Range(0f,0.1f)]
    private float smoothTime = 0.03f;
    private Vector2 currentDelta;
    private Vector2 currentDeltaVelocity;

    private void Start() {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

    }

    private void Update() {
        Vector2 target = new Vector2(Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX,Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY);

        currentDelta = Vector2.SmoothDamp(currentDelta,target,ref currentDeltaVelocity,smoothTime);

        yRotation += currentDelta.x;
        xRotation -= currentDelta.y;

        xRotation = Mathf.Clamp(xRotation ,-90f,90f);
        // moving in x or y i don't know axis (moving player body)
        playerBody.transform.rotation = Quaternion.Euler(0f,yRotation,0f);
        // moving in x or y i don't know axis (moving camera)
        transform.rotation = Quaternion.Euler(xRotation,yRotation,0f);
        // orientation.rotation = Quaternion.Euler(0f,yRotation,0);

    }


}
