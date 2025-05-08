using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject panel;               // Assign in inspector
    public PlayerMovement playerMovement;  // Assign in inspector

    void Update()
    {
        if (panel.activeSelf)
        {
            playerMovement.canMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            playerMovement.canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
