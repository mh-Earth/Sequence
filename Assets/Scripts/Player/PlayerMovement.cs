using UnityEngine;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private CharacterController characterController;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField][Range(0, 1)] float moveSmoothTime = 0.3f;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;
    [SerializeField] private Transform orientation;



    [Header("Gravity")]
    [SerializeField]
    private float GravityForce = -20f;
    private float velocityY;

    [Header("Jumping")]

    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private float jumpForce = 10f;
    private Vector3 playerVelocity;

    private bool groundedPlayer;




    private void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    private void Update()
    {
        MovePlayer();

    }

    private void MovePlayer()
    {

        groundedPlayer = characterController.isGrounded;

        if(!groundedPlayer){

            characterController.slopeLimit = 90;

        }

        if (groundedPlayer && playerVelocity.y < 0)
        {
            characterController.slopeLimit = 50;
            playerVelocity.y = 0f;
        }

        Vector2 target = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        target.Normalize();
        // smoothing movement
        currentDir = Vector2.SmoothDamp(currentDir, target, ref currentDirVelocity, moveSmoothTime);

        // calculate movement direction
        Vector3 Velocity = (orientation.forward * currentDir.y + orientation.right * currentDir.x) * moveSpeed + Vector3.down * velocityY;
        characterController.Move(Velocity * Time.deltaTime);

        jump(jumpForce);

    }

    // Player jump controls
    void jump(float PlayerJumpForce){
        if (Input.GetKey(jumpKey) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(PlayerJumpForce * -1f * GravityForce);
        }

        // adding player gravity 
        // playerGravity();
        playerVelocity.y += GravityForce * Time.deltaTime;
        // jump movement
        characterController.Move(playerVelocity * Time.deltaTime);



    }





}