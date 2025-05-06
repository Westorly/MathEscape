using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;

public class ClientNetworkTransform : NetworkTransform
{
    public static ClientNetworkTransform Instance;

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

    protected override bool OnIsServerAuthoritative(){
        return false;
    }
}
