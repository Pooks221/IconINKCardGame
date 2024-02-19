using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;

public class CardPile : NetworkBehaviour
{
    public List<NetworkObject> cardPileList;
    public TextMeshProUGUI cardCountText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<NetworkObject> getCardList()
    {
        return cardPileList;
    }

    public void setCardPile(List<NetworkObject> cards)
    {
        cardPileList = cards;
        if (cards.Count > 0)
        {
            for (int index = 0; index < cardPileList.Count - 1; index++)
            {
                cardPileList[index].gameObject.GetComponent<Card>().RPC_hideInCardPile(gameObject.GetComponent<NetworkObject>());
            }
            cardPileList[cardPileList.Count - 1].gameObject.GetComponent<Card>().RPC_showCardOnPile(gameObject.GetComponent<NetworkObject>());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Card" && !cardPileList.Contains(other.gameObject.GetComponent<NetworkObject>()))
        {
            cardPileList.Add(other.gameObject.GetComponent<NetworkObject>());
            cardCountText.text = "ADD:"+ cardPileList.Count;
            cardPileList[cardPileList.Count - 1].gameObject.GetComponent<Card>().RPC_showCardOnPile(gameObject.GetComponent<NetworkObject>());
            if (cardPileList.Count > 1)
            {
                cardPileList[cardPileList.Count - 2].gameObject.GetComponent<Card>().RPC_hideInCardPile(gameObject.GetComponent<NetworkObject>());
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Card")
        {
            NetworkObject cardObj = other.gameObject.GetComponent<NetworkObject>();
            if (cardObj != null && cardPileList.Contains(cardObj))
            {
                cardPileList.Remove(cardObj);
                cardCountText.text = "Removed:" + cardPileList.Count;
                if (cardPileList.Count > 0)
                {
                    cardPileList[cardPileList.Count - 1].gameObject.GetComponent<Card>().RPC_showCardOnPile(gameObject.GetComponent<NetworkObject>());
                }
            }
        }
        else if (other.tag == "CardCollision")
        {
            NetworkObject cardObj = other.gameObject.gameObject.GetComponent<NetworkObject>();
            if (cardObj != null && cardPileList.Contains(cardObj))
            {
                cardPileList.Remove(cardObj);
                cardCountText.text = "Removed:" + cardPileList.Count;
                if (cardPileList.Count > 0)
                {
                    cardPileList[cardPileList.Count - 1].gameObject.GetComponent<Card>().RPC_showCardOnPile(gameObject.GetComponent<NetworkObject>());
                }
            }
        }
    }
}
