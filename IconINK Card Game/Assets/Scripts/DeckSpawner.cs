using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using UnityEngine.UI;

public class DeckSpawner : MonoBehaviour
{
    public GameObject RunnerObject;
    private NetworkRunner runner;
    public GameObject prefabCard;
    public Toggle deckToggle;

    private int DECK_SIZE = 10;

    private NetworkObject[] deck;
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
    
    public void connected()
    {
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
    }

    public void ToggleDeck()
    {
        if (deckToggle.isOn)
        {
            SpawnDeck(DECK_SIZE);
        }
        else
        {
            DeleteDeck();
        }
    }

    public void SpawnDeck(int amount)
    {
        deck = new NetworkObject[amount];
        for (int i = 0; i < amount; i++)
        {
            deck[i] = spawnCard();
        }
    }
    public void DeleteDeck()
    {

        for (int i = 0; i < deck.Length; i++)
        {
            runner.Despawn(deck[i]);
        }
        deck = new NetworkObject[0];
    }
    public NetworkObject spawnCard()
    {
        Debug.Log(runner);
        NetworkObject go= runner.Spawn(prefabCard, transform.position, transform.rotation);
        return go;
        //go.transform.parent = gameObject.transform;
    }
}
