using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CardPile : NetworkBehaviour
{
    public List<NetworkObject> cardList;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Card")
        {
            cardList.Add(other.gameObject.GetComponent<NetworkObject>());
            cardList[cardList.Count - 1].gameObject.GetComponent<Card>().showCardOnPile(gameObject);
            if (cardList.Count > 1)
            {
                cardList[cardList.Count - 2].gameObject.GetComponent<Card>().hideInCardPile();
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Card")
        {
            NetworkObject cardObj = other.gameObject.GetComponent<NetworkObject>();
            if (cardObj != null && cardList.IndexOf(cardObj) >= 0)
            {
                cardList.Remove(cardObj);
                if (cardList.Count > 0)
                {
                    cardList[cardList.Count - 1].gameObject.GetComponent<Card>().showCardOnPile(gameObject);
                }
            }
        }
    }
}
