using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 5.0f;
    public float sensitivity = 2.0f;
    public bool canMove = true;
    public Camera playerCamera;
    public float gravity = 10f;
    public float rayDist = 10f;
    public LayerMask interactableLayerMask;
    public GameObject seenObject;
    public bool mouseRay;

    private Vector3 camLoc;
    private CharacterController characterController;
    private float rotationX = 0;
    private RaycastHit hit;
    private RaycastHit lastHit;
    private interactScript interactedScript;
    private interactScript lastInteractedScript;


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

        
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, rayDist, interactableLayerMask) && !mouseRay)
        {
            //interactScript lastInteractedScript = null;
            seenObject = hit.collider.gameObject;
            //interactedScript = hit.collider.GetComponent<interactScript>();
            //if (interactedScript != null)
            //{
            //    interactedScript.isLookedAt = true;
            //}
            
            //if (hit.collider.gameObject != lastHit.collider.gameObject)
            //{
            //    lastInteractedScript.isLookedAt = false;
            //    interactedScript = null;
            //    lastInteractedScript = null;
            //}
            //lastHit = hit;
            //lastInteractedScript = interactedScript;
        }
        else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && mouseRay)
        {
            seenObject = hit.collider.gameObject;
        }
        else
        {
            
            seenObject = null;
            
            //if (interactedScript != null)
            //{
            //    interactedScript.isLookedAt = false;
            //}
            //interactedScript = null;
        }
        Debug.DrawLine(playerCamera.transform.position, playerCamera.transform.position + playerCamera.transform.forward * rayDist);
        
    }

    
}

