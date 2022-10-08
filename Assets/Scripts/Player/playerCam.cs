using UnityEngine;

public class playerCam : MonoBehaviour
{   
    [SerializeField]
    private GameObject playerBody;
    [SerializeField]
    private float senX;
    [SerializeField]
    private float senY;

    private float yRotation;
    private float xRotation;
    [Header("smoothing")]
    [SerializeField][Range(0f,0.1f)]
    private float smoothTime = 0.03f;
    private Vector2 currentDelta;
    private Vector2 currentDeltaVelocity;

    public static float playerUpClamping = -90f;
    public static float playerDownClamping = 85f;

    private void Start() {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Update() {
        Vector2 target = new Vector2(Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX,Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY);

        currentDelta = Vector2.SmoothDamp(currentDelta,target,ref currentDeltaVelocity,smoothTime);

        yRotation += currentDelta.x;
        xRotation -= currentDelta.y;

        xRotation = Mathf.Clamp(xRotation ,playerUpClamping,playerDownClamping);
        // moving in x  axis or i don't know axis (moving player body)
        playerBody.transform.rotation = Quaternion.Euler(0f,yRotation,0f);
        // moving in y axis or i don't know axis (moving player body instead of camera)[for fixing a asshole bug]
        playerBody.transform.rotation = Quaternion.Euler(xRotation,yRotation,0f);
        // orientation.rotation = Quaternion.Euler(0f,yRotation,0);

    }


}
