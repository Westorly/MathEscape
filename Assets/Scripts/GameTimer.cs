using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public TMP_Text winScoreText;   // Reference to a UI Text element in the Win scene to display the score
    private float score;        // The score value
    private bool isPlaying;     // Controls the timer

    private void Awake()
    {
        // Ensure ScoreManager persists between scenes
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Start the timer automatically
        score = 0f;
        isPlaying = true;

        // Subscribe to scene load events to detect the "Win" scene
        SceneManager.sceneLoaded += OnSceneLoaded;

        Topicmanager.Instance.LogCurrentChoices();
    }

    void Update()
    {
        if (isPlaying)
        {
            score += Time.deltaTime;   // Increment score based on time passed
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene is the "Win" scene
        if (scene.name == "End-game Won")
        {
            StopScore();
            DisplayWinScore();
        }
    }

    private void StopScore()
    {
        isPlaying = false;    // Stop incrementing the score
    }

    private void DisplayWinScore()
    {
        if (winScoreText == null)
        {
            // Find the Text component in the Win scene to display the score
            winScoreText = GameObject.Find("WinScoreText")?.GetComponent<TMP_Text>();
        }

        // Update the text with the final score
        if (winScoreText != null)
        {
            string text = Mathf.FloorToInt(score / 60).ToString("D2") + ":" + Mathf.FloorToInt(score % 60).ToString("D2") + ":" + Mathf.FloorToInt(((score % 60) % Mathf.FloorToInt(score % 60)) * 1000).ToString("D3");
            winScoreText.text = "Time: " + text;
        }
    }

    public int GetFinalScore()
    {
        return Mathf.FloorToInt(score);
    }


}
