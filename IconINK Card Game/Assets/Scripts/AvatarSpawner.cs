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
    private NetworkObject go;
    private NetworkObject go2;

    // Start is called before the first frame update
    void Start()
    {
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(go2 != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, go.transform.position, 5f * Time.deltaTime);
            go2.transform.position = newPosition;
        }
    }

    public void spawnAvatar()
    {
       if(runner == null)
        {
            runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
        }
        NetworkObject go = runner.Spawn(prefabAvatar, transform.position, transform.rotation);
        go.transform.parent = gameObject.transform;
        NetworkObject go2 = runner.Spawn(prefabAvatar, transform.position, transform.rotation);
        Debug.Log("go" + go);
        Debug.Log("go2" + go2);

    }

    public void reposition()
    {
        Debug.Log("reposition one" + go2);
        Debug.Log("reposition one" + go);
        Vector3 newPosition = Vector3.Lerp(transform.position, go.transform.position, 5f * Time.deltaTime);
        
        go2.transform.position = newPosition;
        //reposition();
    }

    public void connected()
    {
        Debug.Log("Connected");
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
    }
}
