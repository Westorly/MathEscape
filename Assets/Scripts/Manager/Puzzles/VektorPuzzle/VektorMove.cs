using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VektorMove : MonoBehaviour
{
    public Transform target;
    public GameObject hitEffect;
    public float moveDuration = 2f;
    

    private bool isMoving = false;
    private Vector3 initialPosition;
    private Queue<Vector3> moveQueue = new Queue<Vector3>();

    private void Start()
    {
        if (target != null)
            initialPosition = target.position;
    }

    public void SetMoveSequence(List<Vector3> vectors)
    {
        if (isMoving)
        {
            Debug.LogWarning("Already moving. Ignoring new sequence until current is done.");
            return;
        }

        moveQueue.Clear();
        foreach (var v in vectors)
        {
            // Ensure each move has a magnitude of 0.2
            Vector3 move = v * 0.2f;
            moveQueue.Enqueue(move);
        }

        Debug.Log("Move sequence set:");



        foreach (var v in moveQueue)
        {
            Debug.Log("  Move step: " + v);
        }

       

        StartCoroutine(ProcessMoves()); 
        


        

        
    }

    private IEnumerator ProcessMoves()
    {
        isMoving = true;

        while (moveQueue.Count > 0)
        {
            Vector3 moveDir = moveQueue.Dequeue();
            Vector3 start = target.position;
            Vector3 end = start + moveDir;

            

            // Perform the move smoothly while checking for a collision
            yield return StartCoroutine(MoveSmoothWithCollisionCheck(start, end, moveDir));

            
        }
            

        

        isMoving = false;
    }

    private IEnumerator MoveSmoothWithCollisionCheck(Vector3 start, Vector3 end, Vector3 moveDir)
    {
        float elapsed = 0f;
        Vector3 currentPos = start;

        while (elapsed < moveDuration)
        {
            // Lerp the position over time
            currentPos = Vector3.Lerp(start, end, elapsed / moveDuration);

            // Perform raycasting to check for collisions while moving
            if (Physics.Raycast(start, moveDir.normalized, (currentPos - start).magnitude))
            {
                Debug.LogWarning("Wall hit, resetting to initial position.");
                StartCoroutine(ActivateEffectTemporarily());
                yield return StartCoroutine(MoveSmooth(currentPos, initialPosition));
                isMoving = false;
                yield break;
            }

            target.position = currentPos;
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Final position after movement
        target.position = end;
    }

    private IEnumerator MoveSmooth(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        while (elapsed < moveDuration)
        {
            target.position = Vector3.Lerp(from, to, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        target.position = to;
    }

    


    IEnumerator ActivateEffectTemporarily()
    {
        hitEffect.SetActive(true);
        yield return new WaitForSeconds(2f); // Duration before hiding
        hitEffect.SetActive(false);
    }

    
}
