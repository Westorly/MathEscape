using UnityEngine;
using System.Collections;

public class VektorMove : MonoBehaviour
{
    public Transform target;              // The object to move
    public float stepSize = 0.2f;         // Distance to move each step
    public float moveDuration = 0.2f;     // Duration of each step (smooth transition)

    private bool isMoving = false;

    // Start the movement coroutine
    public void StartMovement()
    {
        if (!isMoving && target != null)
            StartCoroutine(MoveInSteps());
    }

    private IEnumerator MoveInSteps()
    {
        isMoving = true;

        // Get the starting position of the object
        Vector3 start = target.position;

        // Use the local right direction (X-axis) relative to the object’s rotation
        Vector3 movement = transform.right * stepSize;  // Move in the local X direction
        Vector3 end = start + movement;

        // Raycast to check if there's a wall in front of the object in its local X direction
        RaycastHit hit;
        if (Physics.Raycast(start, transform.right, out hit, stepSize))
        {
            if (hit.collider != null)
            {
                // Collision detected with wall, stop movement
                Debug.Log("Wall detected: " + hit.collider.name);
                isMoving = false;
                yield break;  // Stop the movement coroutine
            }
        }

        // If no collision, continue moving in the local X direction
        float elapsed = 0f;
        while (elapsed < moveDuration)
        {
            // Smooth movement from start to end position
            target.position = Vector3.Lerp(start, end, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        target.position = end;  // Ensure the target finishes at the final position
        isMoving = false;
    }
}
