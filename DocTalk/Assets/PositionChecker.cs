using UnityEngine;

public class PositionChecker : MonoBehaviour
{
    public Vector3 targetPosition;

    private Vector3 lastPosition;

    void Start()
    {
        // Store the initial position
        lastPosition = transform.position;
    }

    void LateUpdate()
    {
        // Check if the position has changed from the target position
        if (transform.position != targetPosition)
        {
            // If the position has changed, revert it back to the target position
            transform.position = targetPosition;
        }

        // Update the last position
        lastPosition = transform.position;
    }
}
