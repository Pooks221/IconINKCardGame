using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;

public class AvatarSpawner : MonoBehaviour
{

    public GameObject RunnerObject;
    private NetworkRunner runner;
    public GameObject prefabAvatar;

    // Start is called before the first frame update
    void Start()
    {
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnAvatar()
    {
       if(runner == null)
        {
            runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
        }
        NetworkObject go = runner.Spawn(prefabAvatar, transform.position, transform.rotation);
        go.transform.parent = gameObject.transform;
        
    }

    public void connected()
    {
        Debug.Log("Connected");
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
    }
}
