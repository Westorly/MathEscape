using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    // GameObjects for all puzzles
    public GameObject trigonometrPuzzle;
    public GameObject algebraPuzzle;
    public GameObject andenPuzzle;
    public GameObject diffPuzzle;
    public GameObject vektorPuzzle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initially check each topic and set the corresponding puzzle active accordingly
        if (Topicmanager.Instance.TrigoChoice)
        {
            ActivatePuzzle(trigonometrPuzzle);
        }
        if (Topicmanager.Instance.AlgeChoice)
        {
            ActivatePuzzle(algebraPuzzle);
        }
        if (Topicmanager.Instance.AndenChoice)
        {
            ActivatePuzzle(andenPuzzle);
        }
        if (Topicmanager.Instance.DiffChoice)
        {
            ActivatePuzzle(diffPuzzle);
        }
        if (Topicmanager.Instance.VektorChoice)
        {
            ActivatePuzzle(vektorPuzzle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously check each topic and activate puzzle if chosen
        if (Topicmanager.Instance.TrigoChoice && !trigonometrPuzzle.activeSelf)
        {
            ActivatePuzzle(trigonometrPuzzle);
        }

        if (Topicmanager.Instance.AlgeChoice && !algebraPuzzle.activeSelf)
        {
            ActivatePuzzle(algebraPuzzle);
        }

        if (Topicmanager.Instance.AndenChoice && !andenPuzzle.activeSelf)
        {
            ActivatePuzzle(andenPuzzle);
        }

        if (Topicmanager.Instance.DiffChoice && !diffPuzzle.activeSelf)
        {
            ActivatePuzzle(diffPuzzle);
        }

        if (Topicmanager.Instance.VektorChoice && !vektorPuzzle.activeSelf)
        {
            ActivatePuzzle(vektorPuzzle);
        }
    }

    // Method to activate any given puzzle GameObject
    void ActivatePuzzle(GameObject puzzle)
    {
        if (puzzle != null)
        {
            puzzle.SetActive(true);
            Debug.Log(puzzle.name + " activated!");
        }
    }
}
