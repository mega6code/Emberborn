using System;
using Emberborn.Elements;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    #region Fields
    //Serialized References
    [SerializeField] Animator animator;
    [SerializeField] private ElementalStateManager elementalStateManager;
    [SerializeField] AudioSource grassStep_audio;
    [SerializeField] AudioSource ambience_music;
    [SerializeField] AudioSource flapWing_SFX;
    [SerializeField] AudioSource landGrass_SFX;

    //Serialized Values
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float rotationSpeed = 4f;
    [SerializeField] private float glideGravity = -2f;

    //fields
    InputAction movementControl;
    InputAction jumpControl;
    InputAction glideControl;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraMainTransform;
    #endregion

    #region Methods
    private void OnEnable()
    {
        //Getting the action references from our InputActionAsset singleton 
        movementControl = InputSystem.actions.FindAction("Player/Movement");
        jumpControl = InputSystem.actions.FindAction("Player/Jump");
        glideControl = InputSystem.actions.FindAction("Player/Glide");

        //Attaching methods to our action's events
        //InputSystem.actions.FindAction("Player/Interact").performed += OnInteract;
        InputSystem.actions.FindAction("Player/Ability1").performed += OnAbility1;
        //InputSystem.actions.FindAction("Player/Ability2").performed += OnAbility2;
        InputSystem.actions.FindAction("Player/AbilitySwitch").performed += OnSwitchState;
    }

    private void OnDisable()
    {
        //InputSystem.actions.FindAction("Player/Interact").performed -= OnInteract;
        InputSystem.actions.FindAction("Player/Ability1").performed -= OnAbility1;
        //InputSystem.actions.FindAction("Player/Ability2").performed -= OnAbility2;
        InputSystem.actions.FindAction("Player/AbilitySwitch").performed -= OnSwitchState;
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
        Vector2 movement = movementControl.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);


        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraMainTransform.eulerAngles.y;
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
        if (jumpControl.triggered && groundedPlayer)
        {
            OnJump();
        }


        // Changes the height position of the player..
        if (glideControl.IsPressed() && !groundedPlayer)
        {
            OnGlide();
        }
        else
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
        }

        controller.Move(playerVelocity * Time.deltaTime);

        //JohnStuff vvv
        if (InputSystem.actions.FindAction("Player/Ability2").IsPressed())
        {
            OnAbility2(new InputAction.CallbackContext());
        } 

    }

    public void OnPlatform(Vector3 platfDelta)
    {
        //groundedPlayer = controller.isGrounded;
        controller.Move(platfDelta);
    }

    public void TeleportTo(Vector3 targetPos)
    {
        //top all motion that uppdate function is causing
        playerVelocity = Vector3.zero;

        //disable controller so it doesnt block the position set
        controller.enabled = false;
        transform.position = targetPos;
        controller.enabled = true;
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
    /*private void OnInteract(InputAction.CallbackContext context)
    {
       
    }*/
    public void OnAbility1(InputAction.CallbackContext ctx)
    {
        elementalStateManager.OnAbility(1);
    }
    private void OnAbility2(InputAction.CallbackContext context)
    {
        elementalStateManager.OnAbility(2);
    }

    public void OnSwitchState(InputAction.CallbackContext ctx)
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
#endregion
