using Emberborn.Player;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))] 
public class PlayerController : MonoBehaviour
{

    [SerializeField] Animator animator;
    
    [SerializeField] InputActionReference movementControl;
    [SerializeField] InputActionReference jumpControl;
    [SerializeField] InputActionReference glideControl;

    [SerializeField] InputActionReference abilityControl;
    [SerializeField] InputActionReference switchStateControl;
    [SerializeField] InputActionReference interactControl;

    [SerializeField] AudioSource grassStep_audio;
    [SerializeField] AudioSource ambience_music;
    [SerializeField] AudioSource flapWing_SFX;
    [SerializeField] AudioSource landGrass_SFX;

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float rotationSpeed = 4f;


    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraMainTransform;

    [SerializeField] private ElementalStateManager elementalStateManager;

    [SerializeField] private float glideGravity = -2f;

    private void OnEnable()
    {
        movementControl.action.Enable();
        jumpControl.action.Enable();
        glideControl.action.Enable();
    }

    private void OnDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
        glideControl.action.Disable();
    }
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        cameraMainTransform = Camera.main.transform;
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (!ambience_music.isPlaying)
        {
            ambience_music.Play();
        }

        //is not moving
        if (groundedPlayer && playerVelocity.y < 0)
        {
            OnIdle();
        }

        //movement
        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x ;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);


        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg +cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

            animator.SetBool("IsWalking", true);
            if (groundedPlayer && !grassStep_audio.isPlaying)
            {
                grassStep_audio.Play();
            }
        }
        else
        {
            animator.SetBool("IsWalking", false);
            grassStep_audio.Stop();
        }
        
        // Changes the height position of the player..
        if (jumpControl.action.triggered && groundedPlayer)
        {
            OnJump();
        }


        // Changes the height position of the player..
        if (glideControl.action.IsPressed() && !groundedPlayer)
        {
            OnGlide();
        }
        else
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
        }

        controller.Move(playerVelocity * Time.deltaTime);
        
    }
    public void OnGlide()
    {
        playerVelocity.y += glideGravity * Time.deltaTime;
        animator.SetBool("IsGlinding", true);
        grassStep_audio.Stop();
    }
    public void OnJump()
    {
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        grassStep_audio.Stop();
        animator.SetBool("IsJumping", true);
        animator.SetBool("IsGlinding", false);
    }
    public void OnIdle()
    {
        playerVelocity.y = 0f;
        //animator.SetBool("IsWalking", false);
        animator.SetBool("IsGlinding", false);
        animator.SetBool("IsJumping", false);
    }
    public void OnAbility()
    {

        elementalStateManager.OnAbility();
    }

    public void OnSwitchState()
    {
        elementalStateManager.OnChangeState();
    }
    public void FlapWing_Sound()
    {
        if (!flapWing_SFX.isPlaying)
        {
            flapWing_SFX.PlayOneShot(flapWing_SFX.clip);
        }
    }
    public void LandOnGrass_Sound()
    {
        if (!landGrass_SFX.isPlaying)
        {
            landGrass_SFX.PlayOneShot(landGrass_SFX.clip);
        }
    }
    
}
