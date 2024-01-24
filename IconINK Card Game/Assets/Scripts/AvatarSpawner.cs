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

    public void spawnAvatar()
    {
        
        if (runner == null)
        {
            runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
        }
        NetworkObject go = runner.Spawn(prefabAvatar, transform.position, transform.rotation, runner.LocalPlayer);
        go.transform.SetParent(spawnerlocation);
        go.transform.localRotation = Quaternion.identity;
        go.transform.localPosition = Vector3.zero;
        //go.transform.parent = gameObject.transform;
        //await Task.Delay(10000);
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
        Debug.Log("Connected");
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
    }
}
