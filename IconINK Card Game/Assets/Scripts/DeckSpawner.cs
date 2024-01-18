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

    private int DECK_VALUE_AMOUNT = 13;
    private int DECK_SUIT_AMOUNT = 4;

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
            SpawnDeck(DECK_SUIT_AMOUNT, DECK_VALUE_AMOUNT);
        }
        else
        {
            DeleteDeck();
        }
    }

    public void SpawnDeck(int suitAmount, int valueAmount)
    {
        int deckSize = suitAmount * valueAmount;
        int curCard = 0;
        deck = new NetworkObject[deckSize];
        for (int suit = 0; suit < suitAmount; suit++)
        {
            for (int value = 1; value <= valueAmount; value++)
            {
                deck[curCard] = spawnCard();
                deck[curCard].GetComponent<Card>().setSuitAndValue(getSuit(suit), getValue(value));
                curCard++;
            }
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
        NetworkObject go= runner.Spawn(prefabCard, transform.position, transform.rotation);
        return go;
    }


    private string getValue(int v)
    {
        string tempValue = v.ToString();
        switch (v)
        {
            case 1:
                tempValue = "Ace";
                break;
            case 11:
                tempValue = "Jack";
                break;
            case 12:
                tempValue = "Queen";
                break;
            case 13:
                tempValue = "King";
                break;
            case 14:
                tempValue = "Joker";
                break;
        }
        return tempValue;
    }
    private string getSuit(int s)
    {
        string tempSuit = "Error";
        switch (s)
        {
            case 0:
                tempSuit = "Heart";
                break;
            case 1:
                tempSuit = "Diamond";
                break;
            case 2:
                tempSuit = "Spade";
                break;
            case 3:
                tempSuit = "Club";
                break;
        }
        return tempSuit;
    }
}
