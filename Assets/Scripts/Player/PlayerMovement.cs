using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private CharacterController controller;
    private Camera camera;
    [SerializeField] private GameObject cinemachine;

    [Header("Movement Stats")] 
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float runningSpeed;
    [SerializeField] private float rotationDamp;
    [SerializeField] private float accelerationSpeed;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float jumpForce;
    private float verticalVelocity;
    private bool isJumping;
    private int jumpCount;
    
    [Header("Materials")] 
    [SerializeField] private MeshRenderer renderer;
    [SerializeField] private Material forwardMaterial;
    [SerializeField] private Material backMaterial;
    [SerializeField] private Material leftMaterial;
    [SerializeField] private Material rightMaterial;

    [SerializeField] private GameObject victoryScreen;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void Start()
    {
        currentSpeed = walkingSpeed;
        camera = Camera.main;
        jumpCount = 0;
    }

    private void Update()
    {
        Vector3 movement = CalculateMovement();
        controller.Move(movement * (Time.deltaTime * currentSpeed));
        FaceMovementDirection(movement);
        
        if (verticalVelocity < 0f && controller.isGrounded)
        {
            verticalVelocity = Physics.gravity.y * Time.deltaTime;
            isJumping = false;
            jumpCount = 0;
        }
        else
        {
            verticalVelocity += (Physics.gravity.y / 2) * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (controller.isGrounded || (isJumping && jumpCount < 2)))
        {
            verticalVelocity += jumpForce;
            jumpCount += 1;
            isJumping = true;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            IncreaseSpeed();
        }
        else
        {
            DecreaseSpeed();
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            renderer.material = backMaterial;
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            renderer.material = forwardMaterial;
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            renderer.material = rightMaterial;
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            renderer.material = leftMaterial;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            victoryScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
        }
    }

    private Vector3 CalculateMovement()
    {
        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;
        Vector3 gravity = new Vector3(0f, verticalVelocity, 0f);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        right.y = 0f;
        forward.y = 0f;

        return forward * vertical  + right * horizontal + gravity;
    }

    private void FaceMovementDirection(Vector3 movement)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * rotationDamp); // jebalem ci matke 
    }

    private void IncreaseSpeed()
    {
        if (currentSpeed >= runningSpeed)
        {
            currentSpeed = runningSpeed;
            return;
        }
        currentSpeed += Time.deltaTime * accelerationSpeed;
        currentSpeed = Mathf.Min(currentSpeed, runningSpeed);
    }
    private void DecreaseSpeed()
    {
        if (currentSpeed <= walkingSpeed)
        {
            currentSpeed = walkingSpeed;
            return;
        }
        currentSpeed -= Time.deltaTime * accelerationSpeed;
        currentSpeed = Mathf.Max(currentSpeed, walkingSpeed);
    }
}
