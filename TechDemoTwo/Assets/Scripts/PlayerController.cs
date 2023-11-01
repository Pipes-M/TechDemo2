using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float sensitivity = 2.0f;
    public bool canMove = true;
    public Camera playerCamera;
    public float gravity = 10f;

    private Vector3 camLoc;
    private CharacterController characterController;
    private float rotationX = 0;
    private RaycastHit hit;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (canMove)
        {
            // Player Movement
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Vector3 moveDirection = (transform.TransformDirection(Vector3.forward) * moveZ) + (transform.TransformDirection(Vector3.right) * moveX);
            moveDirection *= moveSpeed;

            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity;
            }
            
            characterController.Move(moveDirection * Time.deltaTime);

            // Player Camera Look
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90, 90);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, mouseX, 0);
        }

        
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 100f))
        {
            Debug.Log(hit.collider.name);
        }
        Debug.DrawLine(playerCamera.transform.position, playerCamera.transform.forward * 100f);
    }
}

