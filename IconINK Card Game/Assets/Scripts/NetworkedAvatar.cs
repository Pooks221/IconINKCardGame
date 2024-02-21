using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkedAvatar : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    public void AvatarSpawnRPC()
    {
        
        //var lipSync = FindObjectOfType<OvrAvatarLipSyncContext>();
        //lipSync.CaptureAudio = true;
        GameObject avatarSDK = GameObject.Find("AvatarSdkManagerMeta");
    }
}
