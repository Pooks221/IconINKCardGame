using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CubeSpawner : MonoBehaviour
{
    public GameObject RunnerObject;
    private NetworkRunner runner;
    public GameObject prefabCube;
    public GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        runner = RunnerObject.GetComponent<NetworkRunner>();
    }

    // Update is called once per frame
    void Update()
    {
        //spawnCube();
    }

    public void spawnCube()
    {
        test.GetComponent<MeshRenderer>().material.color = new Color(Random.value * 255, Random.value * 255, Random.value * 255);
        Debug.Log(runner);
        Debug.Log(prefabCube);
        runner.Spawn(prefabCube, Vector3.zero, Quaternion.identity);
    }
}
