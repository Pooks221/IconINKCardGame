using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;

public class CubeSpawner : NetworkBehaviour
{
    public GameObject RunnerObject;
    private NetworkRunner runner;
    public GameObject prefabCube;
    public GameObject test;

    private bool TEST_MODE = false;

    private List<NetworkObject> allCubes = new List<NetworkObject>();
    // Start is called before the first frame update
    void Start()
    {
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
        //Debug.Log(Fusion.NetworkRunner.GetRunnerForGameObject(gameObject).SessionInfo.PlayerCount);
    }

    public void spawnCube()
    {

        NetworkObject go = runner.Spawn(prefabCube, transform.position, transform.rotation);
        allCubes.Add(go);
        RPC_SetColor(new Color(Random.value, Random.value, Random.value));
        //go.transform.parent = gameObject.transform;
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void RPC_SetColor(Color col)
    {

        test.GetComponent<Renderer>().material.color = col;
    }

    public void connected()
    {
        Debug.Log("Connected");
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);

        if (TEST_MODE)
        {
            spawnCube();
        }
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void RPC_DeleteCubes()
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
