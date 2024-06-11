using Agones;
using Mirror;
using UnityEngine;

public class AgonesGameServer : NetworkManager
{
    [SerializeField]
    private AgonesSdk agones;

    public override void Start()
    {
        base.Start();
        agones ??= GetComponent<AgonesSdk>();
    }
    public override void OnStartServer()
    {
        GameServerReady();
    }
    private async void GameServerReady()
    {
        var ok = await agones.Connect();
        if (!ok)
        {
            Debug.LogError($"{name} | unable to connect to agones");
            return;
        }
        
        ok = await agones.Ready();
        if (!ok)
        {
            Debug.LogError($"{name} | unable to make self ready");
            return;
        }
        Debug.Log($"{name} | game server ready with agones platform");
    }
    private async void GameServerShutdown()
    {
        var ok = await agones.Shutdown();
        if (!ok)
        {
            Debug.LogError($"{name} | unable to indicate server shut down");
        }
    }
}
