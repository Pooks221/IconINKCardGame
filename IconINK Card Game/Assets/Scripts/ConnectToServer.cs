using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectToServer : MonoBehaviour, INetworkRunnerCallbacks
{
    void INetworkRunnerCallbacks.OnConnectedToServer(NetworkRunner runner)
    {

        Debug.Log("connected to server");
    }

    void INetworkRunnerCallbacks.OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
         
    }

    void INetworkRunnerCallbacks.OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
         
    }

    void INetworkRunnerCallbacks.OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
         
    }

    void INetworkRunnerCallbacks.OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
         
    }

    void INetworkRunnerCallbacks.OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
         
    }

    void INetworkRunnerCallbacks.OnInput(NetworkRunner runner, NetworkInput input)
    {
         
    }

    void INetworkRunnerCallbacks.OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
         
    }

    void INetworkRunnerCallbacks.OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
         
    }

    void INetworkRunnerCallbacks.OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
         
    }

    void INetworkRunnerCallbacks.OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
         
    }

    void INetworkRunnerCallbacks.OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
         
    }

    void INetworkRunnerCallbacks.OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
         
    }

    void INetworkRunnerCallbacks.OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
         
    }

    void INetworkRunnerCallbacks.OnSceneLoadDone(NetworkRunner runner)
    {
         
    }

    void INetworkRunnerCallbacks.OnSceneLoadStart(NetworkRunner runner)
    {
         
    }

    void INetworkRunnerCallbacks.OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {

        Debug.Log("setSessionList2");
    }

    void INetworkRunnerCallbacks.OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
         
    }

    void INetworkRunnerCallbacks.OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
         
    }

    // Start is called before the first frame update
    void Start()
    { 

    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
