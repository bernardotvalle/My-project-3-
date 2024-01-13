using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float movementSpeed = 5f;
     

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component on the player GameObject
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Player movement
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize(); // Ensure diagonal movement is not faster

        // Move the player using Rigidbody
        Vector3 newPosition = transform.position + movement * movementSpeed * Time.deltaTime;
        rb.MovePosition(newPosition);

        // Rotate the player to face the movement direction
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720f * Time.deltaTime);
        }
    }
    
}