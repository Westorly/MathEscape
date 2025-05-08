using UnityEngine;
using System.Collections;

public class VektorMove : MonoBehaviour
{
    public Transform target;              
    public Vector3 direction = Vector3.up;
    public float stepSize = 0.2f;
    public float moveDuration = 0.2f;

    private bool isMoving = false;

    public void StartMovement()
    {
        if (!isMoving && target != null)
            StartCoroutine(MoveInSteps());
    }

    private IEnumerator MoveInSteps()
    {
        isMoving = true;

        Vector3 start = target.position;
        Vector3 end = start + direction.normalized * stepSize;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            target.position = Vector3.Lerp(start, end, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        target.position = end;
        isMoving = false;
    }
}
