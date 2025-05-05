using UnityEngine;

public class Topicmanager : MonoBehaviour
{
    bool TrigoChoice = false;
    bool AlgeChoice = false;
    bool AndenChoise = false;
    bool DiffChoice = false;
    bool VektorChoice = false;

    public void ChooseTopic(string topic)
    {
        switch (topic.ToLower())
        {
            case "trigo":
                TrigoChoice = true;
                break;
            case "alge":
                AlgeChoice = true;
                break;
            case "anden":
                AndenChoise = true;
                break;
            case "diff":
                DiffChoice = true;
                break;
            case "vektor":
                VektorChoice = true;
                break;
            default:
                Debug.Log("Unknown topic: " + topic);
                break;
        }
    }
}
