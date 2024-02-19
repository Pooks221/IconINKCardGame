using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Deck : NetworkBehaviour
{
    public List<NetworkObject> cardList;
    public GameObject cardPrefab;


    private int DECK_VALUE_AMOUNT = 13;
    private int DECK_SUIT_AMOUNT = 4;
    private float spawnModifier = 0;
    private NetworkRunner runner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Spawned()
    {
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
    }

    public void SpawnDeck()
    {
        SpawnCards(DECK_SUIT_AMOUNT, DECK_VALUE_AMOUNT);
    }

    public void SpawnCards(int suitAmount, int valueAmount)
    {
        int deckSize = suitAmount * valueAmount;
        int curCard = 0;
        cardList = new List<NetworkObject>();
        for (int suit = 0; suit < suitAmount; suit++)
        {
            for (int value = 1; value <= valueAmount; value++)
            {
                cardList.Add(spawnCard());
                cardList[curCard].GetComponent<Card>().setSuitAndValue(getSuit(suit), getValue(value));
                curCard++;
            }
        }
        gameObject.GetComponent<CardPile>().setCardPile(new List<NetworkObject>(cardList));
    }

    //[Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void RPC_DestroyCard(NetworkObject card)
    {
        if (card.HasStateAuthority)
        {
            runner.Despawn(card);
        }
    }
    public void DestroyDeck()
    {
        foreach(NetworkObject cardObj in cardList)
        if (cardObj.HasStateAuthority)
        {
            runner.Despawn(cardObj);
        }
    }
    public NetworkObject spawnCard()
    {
        NetworkObject go = runner.Spawn(cardPrefab, transform.position, transform.rotation);
        spawnModifier += .01f;
        return go;
    }

    public void ResetDeck()
    {
        List<NetworkObject> tempList = new List<NetworkObject>(cardList);
        cardList.Clear();
        while(tempList.Count > 0)
        {
            int rnd = Mathf.FloorToInt(Random.Range(0, tempList.Count));
            cardList.Add(tempList[rnd]);
            //tempList[rnd].transform.position = this.transform.position;
            //tempList[rnd].transform.rotation = this.transform.rotation;
            //tempList[rnd].transform.GetComponent<Card>().showCardOnPile(gameObject);
            tempList.RemoveAt(rnd);
        }
        gameObject.GetComponent<CardPile>().setCardPile(new List<NetworkObject>(cardList));
    }
    public void ShuffleDeck(List<NetworkObject> discardList)
    {
        List<NetworkObject> cardsStillInDeck = new List<NetworkObject>(gameObject.GetComponent<CardPile>().getCardList());
        List<NetworkObject> tempCards = new List<NetworkObject>();
        for (int i=0; i < discardList.Count; i++)
        {
            cardsStillInDeck.Add(discardList[i]);
        }
        while (cardsStillInDeck.Count > 0)
        {
            int rnd = Mathf.FloorToInt(Random.Range(0, cardsStillInDeck.Count));
            tempCards.Add(cardsStillInDeck[rnd]);
            //cardsStillInDeck[rnd].transform.position = this.transform.position;
            //cardsStillInDeck[rnd].transform.rotation = this.transform.rotation;
            cardsStillInDeck.RemoveAt(rnd);
        }
        gameObject.GetComponent<CardPile>().setCardPile(tempCards);
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
