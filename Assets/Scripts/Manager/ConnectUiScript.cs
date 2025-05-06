using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;


public class ConnectUiScript : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;

    private void Start()
    {
        hostButton.onClick.AddListener(OnHostButtonClicked);
        clientButton.onClick.AddListener(OnClientButtonClicked);
    }
    private void OnHostButtonClicked()
    {
        // Logic to start hosting a game
        Debug.Log("Host button clicked. Starting host...");
        NetworkManager.Singleton.StartHost();
    }
    private void OnClientButtonClicked()
    {
        // Logic to connect to a game as a client
        Debug.Log("Client button clicked. Starting client...");
        NetworkManager.Singleton.StartClient();
    }
}
