using Agones;
using Mirror;
using UnityEngine;

public class AgonesGameServer : NetworkManager
{
    [SerializeField]
    private AgonesSdk agonesSdk;
    [SerializeField]
    private AgonesAlphaSdk agonesAlphaSdk;
    public override void OnApplicationQuit()
    {
        GameServerShutdown();
        base.OnApplicationQuit();
    }
    public override void Awake()
    {
        agonesSdk ??= GetComponent<AgonesSdk>();
        agonesSdk ??= FindObjectOfType<AgonesSdk>();
        if (agonesSdk == null)
        {
            Debug.LogError($"{name} | unable to find AgonesSdk component in scene");
            enabled = false;
            return;
        }
        agonesAlphaSdk ??= GetComponent<AgonesAlphaSdk>();
        agonesAlphaSdk ??= FindObjectOfType<AgonesAlphaSdk>();
        if (agonesAlphaSdk == null)
        {
            Debug.LogError($"{name} | unable to find AgonesAlphaSdk component in scene");
            enabled = false;
            return;
        }
        EnableSdk(false);
        base.Awake();
    }
    public override void OnStartServer()
    {
        EnableSdk();
        GameServerReady();
    }
    public override void OnStopServer()
    {
        GameServerShutdown();
        EnableSdk(false);
    }
    private async void GameServerReady()
    {
        if (agonesSdk == null)
        {
            Debug.LogError($"{name} | unable to find AgonesSdk component in scene");
            return;
        }
        var ok = await agonesSdk.Connect();
        if (!ok)
        {
            Debug.LogError($"{name} | unable to connect to agones");
            return;
        }
        
        ok = await agonesSdk.Ready();
        if (!ok)
        {
            Debug.LogError($"{name} | unable to make self ready");
            return;
        }
        Debug.Log($"{name} | game server ready with agones platform");
    }
    private async void GameServerShutdown()
    {
        var ok = await agonesSdk.Shutdown();
        if (!ok)
        {
            Debug.LogError($"{name} | unable to indicate server shut down");
            return;
        }
        Debug.Log($"{name} | game server shutdown with agones platform");
    }
    private void EnableSdk(bool enableValue = true)
    {
        agonesSdk.enabled = enableValue;
        agonesAlphaSdk.enabled = enableValue;
    }
}
