using TMPro;  // Import the TMP namespace
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VektorMenu : MonoBehaviour
{
    // Declare TMP_InputField for user input
    public TMP_InputField Line1inputField;
    public TMP_InputField Line2inputField;
    public TMP_InputField Line3xinputField;
    public TMP_InputField Line3yinputField;
    public TMP_InputField Line4inputField;
    public TMP_InputField Line5inputField;

    public TMP_Text Line1xResult;
    public TMP_Text Line1yResult;
    public TMP_Text Line2xResult;
    public TMP_Text Line2yResult;
    public TMP_Text Line3xResult;
    public TMP_Text Line3yResult;
    public TMP_Text Line4xResult;
    public TMP_Text Line4yResult;
    public TMP_Text Line5xResult;
    public TMP_Text Line5yResult;

    public VektorMove vektorMover; 

    void Start()
    {
        // Add listeners to input fields to validate input when text changes
        Line1inputField.onValueChanged.AddListener((input) => ValidateFloatInput(Line1inputField, input));
        Line2inputField.onValueChanged.AddListener((input) => ValidateFloatInput(Line2inputField, input));
        Line3xinputField.onValueChanged.AddListener((input) => ValidateFloatInput(Line3xinputField, input));
        Line3yinputField.onValueChanged.AddListener((input) => ValidateFloatInput(Line3yinputField, input));
        Line4inputField.onValueChanged.AddListener((input) => ValidateFloatInput(Line4inputField, input));
        Line5inputField.onValueChanged.AddListener((input) => ValidateFloatInput(Line5inputField, input));
    }

    void Update()
    {
        CalculateVectorsLine1();
        CalculateVectorsLine2();
        CalculateVectorsLine3();
        CalculateVectorsLine4();
        CalculateVectorsLine5();

    }

    void ValidateFloatInput(TMP_InputField inputField, string input)
    {
        // Check if the input is a valid float or an empty string
        if (IsValidFloat(input))
        {
            // Input is valid, do nothing or you can process it further
        }
        else
        {
            // If the input is invalid, reset the input field
            inputField.text = string.Empty;  // Clear the invalid input
        }
    }

    // Function to check if the string is a valid float
    bool IsValidFloat(string input)
    {
        // Use a simple regular expression to check if the input is a valid float number
        if (string.IsNullOrEmpty(input)) return true;  // Allow empty input (before the user starts typing)

        // Regular expression for a valid float (with optional minus sign, digits, and decimal point)
        string pattern = @"^-?\d*(\.\d*)?$";

        return System.Text.RegularExpressions.Regex.IsMatch(input, pattern);
    }



    //Function til at beregne vektorerne
    void CalculateVectorsLine1()
    {
        // Check if input is empty before parsing
        if (string.IsNullOrEmpty(Line1inputField.text))
        {
            Line1xResult.text = "?";
            Line1yResult.text = "?";
            return;
        }

        // Safe parsing
        if (float.TryParse(Line1inputField.text, out float line1))
        {
            float resultLine1x = line1 * 1f;
            float resultLine1y = line1 * 0f; // Example vector math

            Line1xResult.text = resultLine1x.ToString("F0");
            Line1yResult.text = resultLine1y.ToString("F0");
        }
        else
        {
            // Optionally handle invalid input here (though your ValidateFloatInput should prevent this)
            Line1xResult.text = "?";
            Line1yResult.text = "?";
        }
    }

    void CalculateVectorsLine2()
    {
        // Check if input is empty before parsing
        if (string.IsNullOrEmpty(Line2inputField.text))
        {
            Line2xResult.text = "?";
            Line2yResult.text = "?";
            return;
        }

        // Safe parsing
        if (float.TryParse(Line2inputField.text, out float input))
        {
            // (3, 0) + (input, -1)
            float resultX = 3f + input;
            float resultY = 0f + (-1f);

            Line2xResult.text = resultX.ToString("F0");
            Line2yResult.text = resultY.ToString("F0");
        }
        else
        {
            Line2xResult.text = "?";
            Line2yResult.text = "?";
        }
    }

    void CalculateVectorsLine3(){
        // Check for empty input in either X or Y field
        if (string.IsNullOrEmpty(Line3xinputField.text) || string.IsNullOrEmpty(Line3yinputField.text))
        {
            Line3xResult.text = "?";
            Line3yResult.text = "?";
            return;
        }

        // Try parsing both input fields
        if (float.TryParse(Line3xinputField.text, out float inputX) &&
            float.TryParse(Line3yinputField.text, out float inputY))
        {
            // (input, input) - (3, 2)
            float resultX = inputX - 3f;
            float resultY = inputY - 2f;

            Line3xResult.text = resultX.ToString("F0"); // No decimals
            Line3yResult.text = resultY.ToString("F0");
        }
        else
        {
            Line3xResult.text = "?";
            Line3yResult.text = "?";
        }
    }

    void CalculateVectorsLine4()
    {
        // Check if input is empty before parsing
        if (string.IsNullOrEmpty(Line4inputField.text))
        {
            Line4xResult.text = "?";
            Line4yResult.text = "?";
            return;
        }

        // Safe parsing
        if (float.TryParse(Line4inputField.text, out float line4))
        {
            float resultLine4x = line4 * 0f;
            float resultLine4y = line4 * (-1f); // Example vector math

            Line4xResult.text = resultLine4x.ToString("F0");
            Line4yResult.text = resultLine4y.ToString("F0");
        }
        else
        {
            // Optionally handle invalid input here (though your ValidateFloatInput should prevent this)
            Line4xResult.text = "?";
            Line4yResult.text = "?";
        }
    }

    void CalculateVectorsLine5(){
        // Check if input is empty before parsing
        if (string.IsNullOrEmpty(Line5inputField.text))
        {
            Line5xResult.text = "?";
            Line5yResult.text = "?";
            return;
        }

        // Safe parsing
        if (float.TryParse(Line5inputField.text, out float input))
        {
            // (3, 0) + (input, -1)
            float resultX = 2f - input;
            float resultY = 1f - 1f;

            Line5xResult.text = resultX.ToString("F0");
            Line5yResult.text = resultY.ToString("F0");
        }
        else
        {
            Line5xResult.text = "?";
            Line5yResult.text = "?";
        }

    }

    

    public void StartMovingTarget()
    {
        List<Vector3> moves = new List<Vector3>();

        Debug.Log("StartMovingTarget() called — beginning vector movement sequence.");

        // Read all calculated results and build vector list
        moves.Add(ParseResult(Line1xResult, Line1yResult));
        moves.Add(ParseResult(Line2xResult, Line2yResult));
        moves.Add(ParseResult(Line3xResult, Line3yResult));
        moves.Add(ParseResult(Line4xResult, Line4yResult));
        moves.Add(ParseResult(Line5xResult, Line5yResult));

        vektorMover.SetMoveSequence(moves);
    }

    private Vector3 ParseResult(TMP_Text xText, TMP_Text yText)
    {
        if (float.TryParse(xText.text, out float x) && float.TryParse(yText.text, out float y))
            return new Vector3(x, y, 0); // Assuming 2D movement on XZ plane
        return Vector3.zero;
    }



}

   


    


