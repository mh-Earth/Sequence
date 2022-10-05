// Make the player camera follow the player

using UnityEngine;

public class followPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject playerCameraObject;
    void Update()
    {
        transform.position = playerCameraObject.transform.position;
        
    }
}
