using System;
using Mirror;
using Agones;
using Grpc.Core;
using UnityEngine;

public class AgonesNetworkManager : NetworkManager
{
    private AgonesSDK _agones;
    
    public override void OnStartServer()
    {
        ReadyForPlayers();
    }

    public override void OnStopServer()
    {
        ShutDownGameSessions();
    }
    private async void ReadyForPlayers()
    {
        try
        {
            var status = await _agones.ReadyAsync();
            if (status.StatusCode != StatusCode.OK)
            {
                Debug.LogError($"{name} | non-ok status: {status.StatusCode}");
                Debug.LogError($"{name} | details: {status.Detail}");
                return;
            }
            Debug.Log($"{name} | Game Server is ready for players");
        } catch (Exception e)
        {
            Debug.LogError($"{name} | Error: {e.Message}");
        }
    }
    private async void ShutDownGameSessions()
    {
        try
        {
            var status = await _agones.ShutDownAsync();
        }
        catch (Exception e)
        {
            Debug.LogError($"{name} | Error: {e.Message}");
        }
    }
    public override void Awake()
    {
        _agones = new AgonesSDK();
        base.Awake();
    }
}
