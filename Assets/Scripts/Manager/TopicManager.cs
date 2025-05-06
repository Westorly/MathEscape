using UnityEngine;

public class Topicmanager : MonoBehaviour
{
    public static Topicmanager Instance;

    public bool TrigoChoice = false;
    public bool AlgeChoice = false;
    public bool AndenChoice = false;
    public bool DiffChoice = false;
    public bool VektorChoice = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }

    public void LogCurrentChoices()
    {
        Debug.Log("Trigonometri: " + TrigoChoice);
        Debug.Log("Algebra: " + AlgeChoice);
        Debug.Log("Anden: " + AndenChoice);
        Debug.Log("Differential: " + DiffChoice);
        Debug.Log("Vektorer: " + VektorChoice);
    }

    public void ChooseTopic(string topic)
    {
        switch (topic.ToLower())
        {
            case "trigo":
                Debug.Log("TRUE TRIGOCHOICE");
                TrigoChoice = true;
                break;
            case "alge":
                Debug.Log("TRUE ALGECCHOICE");
                AlgeChoice = true;
                break;
            case "anden":
                Debug.Log("TRUE ANDENCHOICE");
                AndenChoice = true;
                break;
            case "diff":
                Debug.Log("TRUE DIFFCHOICE");
                DiffChoice = true;
                break;
            case "vektor":
                Debug.Log("TRUE VEKTORCHOICE");
                VektorChoice = true;
                break;
            default:
                Debug.Log("Unknown topic: " + topic);
                break;
        }
    }

    public void UnChooseTopic(string topic)
    {
        switch (topic.ToLower())
        {
            case "trigo":
                Debug.Log("FALSE TRIGOCHOICE");
                TrigoChoice = false;
                break;
            case "alge":
                Debug.Log("FALSE ALGECCHOICE");
                AlgeChoice = false;
                break;
            case "anden":
                Debug.Log("FALSE ANDENCHOICE");
                AndenChoice = false;
                break;
            case "diff":
                Debug.Log("FALSE DIFFCHOICE");
                DiffChoice = false;
                break;
            case "vektor":
                Debug.Log("FALSE VEKTORCHOICE");
                VektorChoice = false;
                break;
            default:
                Debug.Log("Unknown topic: " + topic);
                break;
        }
    }
}
