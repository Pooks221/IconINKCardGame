using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;

public class CubeSpawner : MonoBehaviour
{
    public GameObject RunnerObject;
    private NetworkRunner runner;
    public GameObject prefabCube;
    public GameObject test;

    private List<NetworkObject> allCubes = new List<NetworkObject>();
    // Start is called before the first frame update
    void Start()
    {
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //spawnCube();
       
        //Debug.Log(Fusion.NetworkRunner.GetRunnerForGameObject(gameObject).SessionInfo.PlayerCount);
    }

    public void spawnCube()
    {
        
        NetworkObject go = runner.Spawn(prefabCube, transform.position, transform.rotation);
        allCubes.Add(go);
        //go.transform.parent = gameObject.transform;
    }

    public void connected()
    {
        Debug.Log("Connected");
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
    }

    public void DeleteCubes()
    {
        Debug.Log("Delete:" + allCubes.Count);
        for (int i = 0; i < allCubes.Count; i++)
        {
            Debug.Log("Deleted:"+i);
            runner.Despawn(allCubes[i]);
        }
        allCubes.Clear();
    }
}
