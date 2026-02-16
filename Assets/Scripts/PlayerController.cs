using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))] 
public class PlayerController : MonoBehaviour
{

    [SerializeField] Animator animator;
    
    [SerializeField] InputActionReference movementControl;
    [SerializeField] InputActionReference jumpControl;
    [SerializeField] InputActionReference glideControl;

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float rotationSpeed = 4f;


    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraMainTransform;

    private Rigidbody rb; //
    [SerializeField] private float fallForce = 0.1f;

    private void OnEnable()
    {
        movementControl.action.Enable();
        jumpControl.action.Enable();
    }

    private void OnDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
    }
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        cameraMainTransform = Camera.main.transform;
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            OnIdle();
        }

        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x ;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);


        // Changes the height position of the player..
        if (jumpControl.action.triggered && groundedPlayer)
        {
            OnJump();
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg +cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            animator.SetBool("IsWalking", true);
        }

        // Changes the height position of the player..
        if (glideControl.action.inProgress && !groundedPlayer)
        {
            OnGlide();
        }
        else
        {
            rb.useGravity = true;
            animator.SetBool("IsGlinding", false);
        }
    }
    public void OnGlide()
    {
        animator.SetBool("IsGlinding", true);

        rb.useGravity = false; // turn off normal gravity
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, -fallForce, rb.linearVelocity.z); // constant slow fall;
    }

    public void OnJump()
    {
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        animator.SetBool("IsJumping", true);
        animator.SetBool("IsGlinding", false);
    }
    public void OnIdle()
    {
        playerVelocity.y = 0f;
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsGlinding", false);
        animator.SetBool("IsJumping", false);
    }
    

}
