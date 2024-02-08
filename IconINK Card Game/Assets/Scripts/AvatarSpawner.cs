using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System;
using Fusion.Sockets;
using Oculus.Platform;
using Oculus.Avatar2;
using System.Threading.Tasks;

public class AvatarSpawner : MonoBehaviour
{

    public GameObject RunnerObject;
    private NetworkRunner runner;
    public GameObject prefabAvatar;
    private NetworkObject go;
    private NetworkObject go2;

    [SerializeField] Transform spawnerlocation;

    // Start is called before the first frame update
    //Comment to test git
    void Start()
    {
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //if(go2 != null)
        //{
        //    Vector3 newPosition = Vector3.Lerp(transform.position, go.transform.position, 5f * Time.deltaTime);
        //    go2.transform.position = newPosition;
        //}
    }

    public async void spawnAvatar()
    {
        
        if (runner == null)
        {
            runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
        }
        NetworkObject go = runner.Spawn(prefabAvatar, transform.position, transform.rotation, runner.LocalPlayer);
        var lipSync = FindObjectOfType<OvrAvatarLipSyncContext>();
        lipSync.CaptureAudio = true;
        //gameObject.GetComponent<go>().SetLipSync(lipSync);
        go.transform.SetParent(spawnerlocation);
        //go.transform.parent = gameObject.transform;

        //link sample avatar entity
        GameObject avatarSDK = GameObject.Find("AvatarSdkManagerMeta");
        go.GetComponent<SampleAvatarEntity>().SetBodyTracking(avatarSDK.GetComponent<SampleInputManager>());
        go.GetComponent<SampleAvatarEntity>().SetFacePoseProvider(avatarSDK.GetComponent<SampleFacePoseBehavior>());
        go.GetComponent<SampleAvatarEntity>().SetEyePoseProvider(avatarSDK.GetComponent<SampleEyePoseBehavior>());
        go.GetComponent<SampleAvatarEntity>().SetLipSync(GameObject.Find("LipSyncInput").GetComponent<OvrAvatarLipSyncBehavior>());


        await Task.Delay(10000);
        
        //Vector3 newPosition = new Vector3(0, 0, 0);
        //go.transform.position = newPosition;
        //go.transform.SetParent(spawnerlocation);
        Debug.Log(go);
        

    }

    public void reposition()
    {
        //Debug.Log("reposition one" + go2);
        //Debug.Log("reposition one" + go);
        Vector3 newPosition = new Vector3 (0, 0, 0);
        
        spawnerlocation.transform.position = newPosition;
        //reposition();
    }

    public void connected()
    {
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
    }
}
