using UnityEngine;
using System.Collections;

public class VektorMove : MonoBehaviour
{
    public Vector3 direction = Vector3.right;
    public float stepSize = 0.3f;
    public float moveDuration = 0.2f;
    public float waitTime = 0.1f;

    private bool isMoving = false;

    public void StartMovement()
    {
        if (!isMoving)
            StartCoroutine(MoveInSteps());
    }

    private IEnumerator MoveInSteps()
    {
        isMoving = true;

        // You can remove the loop if you only want to move once
        Vector3 start = transform.position;
        Vector3 end = start + direction.normalized * stepSize;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            transform.position = Vector3.Lerp(start, end, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = end;
        isMoving = false;
    }
}
