using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System.Threading.Tasks;

public class RPCTestSpawner : NetworkBehaviour
{
    public GameObject RunnerObject;
    private NetworkRunner runner;
    public GameObject PlacardPrefab;
    public GameObject prefabDeck;
    public GameObject Location1;
    public GameObject Location2;
    public GameObject Location3;
    public GameObject Location4;
    private NetworkObject go;
    private NetworkObject HandPlacard1;
    private NetworkObject HandPlacard2;
    private NetworkObject HandPlacard3;
    private NetworkObject HandPlacard4;
    // Start is called before the first frame update
    void Start()
    {
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void connected()
    {

        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
        Debug.Log(runner);
        NetworkObject HandPlacard1 = runner.Spawn(PlacardPrefab, Location1.transform.position, Location1.transform.rotation);
        NetworkObject HandPlacard2 = runner.Spawn(PlacardPrefab, Location2.transform.position, Location2.transform.rotation);
        NetworkObject HandPlacard3 = runner.Spawn(PlacardPrefab, Location3.transform.position, Location3.transform.rotation);
        
    }

    public async void ButtonPressed()
    {
       runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
        Debug.Log(runner);
        await Task.Delay(1000);
        

        /*Debug.Log(prefabDeck);
        NetworkObject go = runner.Spawn(prefabDeck, transform.position, transform.rotation);
        Debug.Log("after spawn");
        await Task.Delay(1000);
        Debug.Log("after delay");
        //RPCTest testScript = go.GetComponent<RPCTest>();
        Debug.Log("after get component");
        //testScript.PressedButton();
        Debug.Log("after calling to other script");*/
    }

}
