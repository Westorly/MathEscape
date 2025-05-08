using UnityEngine;
using UnityEngine.UI;

public class InputFieldUnlocker : MonoBehaviour
{
    public InputField firstInputField;
    public InputField secondInputField;
    public Button checkButton;

    [SerializeField] private string correctAnswer = "1";

    void Start()
    {
        // Sørg for at andet felt er deaktiveret i starten
        secondInputField.interactable = false;

        // Lyt til klik på knappen
        checkButton.onClick.AddListener(CheckFirstAnswer);
    }

    void CheckFirstAnswer()
    {
        if (firstInputField.text.Trim().ToLower() == correctAnswer.ToLower())
        {
            secondInputField.interactable = true;
            Debug.Log("Korrekt svar! Andet felt er nu åbent.");
        }
        else
        {
            Debug.Log("Forkert svar. Prøv igen.");
        }
    }
}
