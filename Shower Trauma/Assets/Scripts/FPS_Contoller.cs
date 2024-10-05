using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Contoller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;
    public float jumpForce = 5f;
    public float gravity = 9.81f;
    public Camera playerCamera; // Public variable for the camera

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("CharacterController component missing from the capsule object.");
            enabled = false; // Disable the script if there's no CharacterController
            return;
        }

        if (playerCamera == null)
        {
            Debug.LogError("Player Camera is not assigned.");
            enabled = false; // Disable the script if there's no Camera assigned
            return;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Movement
        float moveForwardBackward = Input.GetAxis("Vertical") * moveSpeed;
        float moveLeftRight = Input.GetAxis("Horizontal") * moveSpeed;

        Vector3 move = transform.right * moveLeftRight + transform.forward * moveForwardBackward;
        moveDirection.x = move.x;
        moveDirection.z = move.z;

        // Jumping and Gravity
        if (characterController.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        // Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        transform.Rotate(0, mouseX, 0);

        if (playerCamera != null)
        {
            playerCamera.transform.localRotation = Quaternion.Euler(playerCamera.transform.localEulerAngles.x - mouseY, 0, 0);
        }

        //when get's near another object "player" and press E debug log will show
        if (Input.GetKeyDown(KeyCode.E))
        {
            Cuffplayer();
        }
    }

    void Cuffplayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 3))
        {
            if (hit.collider.tag == "Player")
            {
                Debug.Log("Player Cuffed");
            }
        }

    }

}
