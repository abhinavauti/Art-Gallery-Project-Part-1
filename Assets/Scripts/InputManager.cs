using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    PlayerController playerController;
    AnimatorController animatorController;
    public Vector2 movementInput;
    public Vector2 cameraInput;
    public float moveAmount;
    public float cameraInputX;
    public float cameraInputY;
    public float verticalInput;
    public float horizontalInput;
    public bool b_Input;
    public bool ctrl_Input;
    public bool jump_Input;

    private void Awake()
    {
        animatorController = GetComponent<AnimatorController>();
        playerController = GetComponent<PlayerController>();
    }


    private void OnEnable() 
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            playerControls.PlayerActions.B.performed += i => b_Input = true;
            playerControls.PlayerActions.B.canceled += i => b_Input = false;
            playerControls.PlayerActions.Ctrl.performed += i => ctrl_Input = true;
            playerControls.PlayerActions.Ctrl.canceled += i => ctrl_Input = false;
            playerControls.PlayerActions.Jump.performed += i => jump_Input = true;
        }

        playerControls.Enable();
    }

    private void OnDisable() 
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSprintingInput();
        HandleWalkingInput();
        HandleJumpingInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;
        
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorController.UpdateAnimatorValues(0, moveAmount, playerController.isSprinting);
    }

    private void HandleSprintingInput()
    {
        if (b_Input && moveAmount > 0.5f)
        {
            playerController.isSprinting = true;
        }
        else
        {
            playerController.isSprinting = false;
        }
    }

    private void HandleWalkingInput()
    {
        bool isWalking = ctrl_Input;

    if (isWalking)
    {
        // When "Ctrl" is pressed, set moveAmount to 0.5 to indicate walking
        moveAmount = 0.5f;
    }
    else
    {
        // When "Ctrl" is not pressed, set moveAmount based on the actual input
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
    }

    // Pass the updated moveAmount to the UpdateAnimatorValues method
        animatorController.UpdateAnimatorValues(0, moveAmount, playerController.isSprinting);
    }

    private void HandleJumpingInput()
    {
        if (jump_Input)
        {
            jump_Input = false;
            playerController.HandleJumping();
        }
    }

}
