using System;
using Emberborn.Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField] PlayerMotor playerMotor;
    [SerializeField] ElementalStateManager elementalStateManager;

    private Vector2 moveInput;
    private bool jumpPressed;
    private InputSystem_Actions controls;
    private bool isActive = true;


    private void Awake()
    {
        controls = new InputSystem_Actions();
        controls.Enable();


        controls.InLevel.Jump.performed += OnJump; //its called while the action is happening, is called at the same time as performed
        //controls.InLevel.Jump.canceled += OnJump; //happens when the action is canceled

        controls.InLevel.Move.performed += OnMove;
        controls.InLevel.Move.canceled += OnMove; //when stop pressing, the player stops to walk

        controls.InLevel.Ability.performed += OnAbility;
        controls.InLevel.SwitchState.performed += OnSwitchState;

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

    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        jumpPressed = true;
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void OnAbility(InputAction.CallbackContext context)
    {
        elementalStateManager.OnAbility();
    }

    private void OnSwitchState(InputAction.CallbackContext context)
    {
        elementalStateManager.OnChangeState();
    }

}
