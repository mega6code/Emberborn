using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField] PlayerMotor playerMotor;

    private Vector2 moveInput;
    private bool jumpPressed;
    private InputSystem_Actions controls;
    private bool isActive = true;
    private bool heldGlind = false; //is not pressing the key (shift)

    private void Awake()
    {
        controls = new InputSystem_Actions();
        controls.Enable();


        //controls.InLevel.Jump.performed += OnJump; //its called while the action is happening, is called at the same time as performed
        ////controls.InLevel.Jump.canceled += OnJump; //happens when the action is canceled

        //controls.InLevel.Move.performed += OnMove;
        //controls.InLevel.Move.canceled += OnMove; //when stop pressing, the player stops to walk

        //controls.InLevel.Glind.performed += OnGlind;
        //controls.InLevel.Glind.canceled += OnGlind;

    }

    private void FixedUpdate()
    {
        if (!isActive) return;
        playerMotor.OnMove(moveInput);

        if (jumpPressed)
        {
            playerMotor.OnJump();
            jumpPressed = false; // consume jump
        }

         if (heldGlind == false)
         {
            return;
         }

    }

    private void OnGlind(InputAction.CallbackContext ctx)
    {
        //heldGlind = ctx.ReadValue<bool>();
        //say smth like, if there is input (shift), then heldGlind is true
        heldGlind = ctx.ReadValueAsButton();
        playerMotor.OnGlind(heldGlind);

    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        jumpPressed = true;
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

}
