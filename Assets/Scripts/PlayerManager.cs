using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Animator animator;
    InputManager inputManager;
    PlayerController playerController;
    CameraManager cameraManager;
    public bool isInteracting;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
        cameraManager = FindFirstObjectByType<CameraManager>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update() 
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate() 
    {
        playerController.HandleAllMovements();
    }

    private void LateUpdate() 
    {
        cameraManager.HandleAllCameraMovements();
        isInteracting = animator.GetBool("isInteracting");
        playerController.isJumping = animator.GetBool("isJumping");
        animator.SetBool("isGrounded", playerController.isGrounded);
    }

}
