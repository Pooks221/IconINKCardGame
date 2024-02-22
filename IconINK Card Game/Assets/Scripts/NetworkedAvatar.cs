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
        Debug.Log("Inside Method");
        //var lipSync = FindObjectOfType<OvrAvatarLipSyncContext>();
        //lipSync.CaptureAudio = true;
        GameObject avatarSDK = GameObject.Find("AvatarSdkManagerMeta");
        Debug.Log("After find");
        Debug.Log(avatarSDK);
        GetComponent<SampleAvatarEntity>().SetBodyTracking(avatarSDK.GetComponent<SampleInputManager>());
        GetComponent<SampleAvatarEntity>().SetFacePoseProvider(avatarSDK.GetComponent<SampleFacePoseBehavior>());
        GetComponent<SampleAvatarEntity>().SetEyePoseProvider(avatarSDK.GetComponent<SampleEyePoseBehavior>());

        //GetComponent<SampleAvatarEntity>().SetLipSync(GameObject.Find("LipSyncInput").GetComponent<OvrAvatarLipSyncBehavior>());
    }
}
