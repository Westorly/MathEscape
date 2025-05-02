using UnityEngine;
using UnityEngine.UI;

public class CheckmarkToggle : MonoBehaviour
{
    public bool TopicTriBool = false;
    public bool TopicAlgeBool = false;
    public bool TopicFunkBool = false;
    public bool TopicDiffBool = false;
    public bool TopicVekBool = false;

    public Image checkmarkImage; // The shared checkmark image

    // Topic button positions or anchor points
    public RectTransform topicTriButton;
    public RectTransform topicAlgeButton;
    public RectTransform topicFunkButton;
    public RectTransform topicDiffButton;
    public RectTransform topicVekButton;

    // Toggle each topic's checkmark visibility
    public void ToggleTopicTri()
    {
        TopicTriBool = !TopicTriBool;
        UpdateCheckmarkVisibility(TopicTriBool, topicTriButton);
    }

    public void ToggleTopicAlge()
    {
        TopicAlgeBool = !TopicAlgeBool;
        UpdateCheckmarkVisibility(TopicAlgeBool, topicAlgeButton);
    }

    public void ToggleTopicFunk()
    {
        TopicFunkBool = !TopicFunkBool;
        UpdateCheckmarkVisibility(TopicFunkBool, topicFunkButton);
    }

    public void ToggleTopicDiff()
    {
        TopicDiffBool = !TopicDiffBool;
        UpdateCheckmarkVisibility(TopicDiffBool, topicDiffButton);
    }

    public void ToggleTopicVek()
    {
        TopicVekBool = !TopicVekBool;
        UpdateCheckmarkVisibility(TopicVekBool, topicVekButton);
    }

    // Update the checkmark visibility and position
    private void UpdateCheckmarkVisibility(bool isVisible, RectTransform buttonPosition)
    {
        checkmarkImage.gameObject.SetActive(isVisible);

        if (isVisible && buttonPosition != null)
        {
            // Position the checkmark image next to the selected topic button
            checkmarkImage.rectTransform.position = buttonPosition.position;
        }
    }
}
