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
        test.GetComponent<MeshRenderer>().material.color = new Color(Random.value * 255, Random.value * 255, Random.value * 255);
        NetworkObject go = runner.Spawn(prefabCube, transform.position, transform.rotation);
        go.GetComponent<MeshRenderer>().material.color = new Color(Random.value * 255, Random.value * 255, Random.value * 255);
    }

    public void connected()
    {
        Debug.Log("Connected");
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
    }
}
