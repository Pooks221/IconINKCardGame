using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;

public class CardPile : NetworkBehaviour
{
    public List<NetworkObject> cardList;
    public TextMeshProUGUI cardCountText;
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
            cardCountText.text = "ADD:"+cardList.Count;
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
            if (cardObj != null && cardList.Contains(cardObj))
            {
                cardList.Remove(cardObj);
                cardCountText.text = "Removed:" + cardList.Count;
                if (cardList.Count > 0)
                {
                    cardList[cardList.Count - 1].gameObject.GetComponent<Card>().showCardOnPile(gameObject);
                }
            }
        }
        else if (other.tag == "CardCollision")
        {
            NetworkObject cardObj = other.gameObject.gameObject.GetComponent<NetworkObject>();
            if (cardObj != null && cardList.Contains(cardObj))
            {
                cardList.Remove(cardObj);
                cardCountText.text = "Removed:" + cardList.Count;
                if (cardList.Count > 0)
                {
                    cardList[cardList.Count - 1].gameObject.GetComponent<Card>().showCardOnPile(gameObject);
                }
            }
        }
    }
}
