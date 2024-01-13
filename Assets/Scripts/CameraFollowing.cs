using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform target;  // Reference to the player's transform
    public float distance = 9f;  // Distance from the player
    public float height = 7f;    // Height above the player
    public float smoothSpeed = 0.125f;  // Smoothing speed for camera movement

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraFollow: Target is not assigned!");
            return;
        }

        // Calculate the desired position for the camera
        Vector3 desiredPosition = target.position + Vector3.up * height - target.forward * distance;

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Make the camera look at the player
        transform.LookAt(target.position);
    }
}
