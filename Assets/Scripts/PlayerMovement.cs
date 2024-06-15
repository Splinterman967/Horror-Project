using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

   
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float minMovement = 1f;
    [SerializeField] float footStepSoundInterval;

    private CharacterController characterController;
    private Camera playerCamera;    
    private AudioSource audioSource;

    private float verticalRotation = 0f;
    private Vector3 lastPosition;
    private Vector3 currentPosition;
    private bool isMoving = false;  
    void Start()
    {
        StartCoroutine(isMoved());

        Cursor.lockState = CursorLockMode.Locked;

        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();

        if (playerCamera == null)
        {
            Debug.LogError("FPS Controller requires a camera child object to function properly.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }
  
    IEnumerator isMoved()
    {
        while (true)
        {
            //Checks if player is moved
            lastPosition = transform.position;
            yield return new WaitForSeconds(footStepSoundInterval);
            currentPosition = transform.position;

            float movDistance = Vector3.Distance(lastPosition, currentPosition);

            //If player moved certain distance than footstep SFX plays
            if( movDistance > minMovement)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();  
            }
        }
        
    }
    private void Movement()
    {
        if (characterController != null)
        {
            // Rotation
            float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.Rotate(0, horizontalRotation, 0);

            verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
            playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

            // Movement
            
               
            //Debug.Log("Vertical :  " + Input.GetAxis("Vertical") + "   Horizontal:  " + Input.GetAxis("Horizontal"));
            float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
            float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

            Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);
            speed = transform.rotation * speed;

            characterController.SimpleMove(speed);
       }
    }
}
