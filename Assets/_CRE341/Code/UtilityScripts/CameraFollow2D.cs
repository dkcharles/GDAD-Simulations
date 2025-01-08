using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform player;       // Reference to the player's transform.
    public float smoothSpeed = 0.125f;  // Speed at which the camera will follow.
    public Vector3 offset;         // Offset between the camera and the player.

    void Update()
    {
        // Ensure the player transform is assigned.
        if (player == null)
        {
            Debug.LogWarning("Player not assigned to the CameraFollow2D script.");
            return;
        }

        // Desired position of the camera.
        Vector3 desiredPosition = player.position + offset;
        
        // Smoothly interpolate between the camera's current position and the desired position.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Update the camera's position.
        transform.position = smoothedPosition;
    }
}
