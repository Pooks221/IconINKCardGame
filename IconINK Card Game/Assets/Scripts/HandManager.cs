using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;


public class HandManager : MonoBehaviour
{
    private List<NetworkObject> CardsInHand = new List<NetworkObject>();

    public Transform Pos1;
    public Transform Pos2;
    public Transform Pos3;
    public Transform Pos4;
    public Transform Pos5;
    public GameObject Halo;
    public AudioSource sfx;

    private Vector3 startingPos;

    private void Start()
    {
        startingPos = Pos3.localPosition;
        Halo.GetComponent<Renderer>().enabled = false;
    }

    public void RecieveCard(NetworkObject card)
    {
        if (!CardsInHand.Contains(card))
        {
            Pos3.localPosition = (Pos3.localPosition + new Vector3(-0.01f, 0, 0));
            CardsInHand.Add(card);
            ReorderCards();
        }
        else
        {
            CardsInHand.Remove(card);
            CardsInHand.Add(card);
            ReorderCards();
        }
 
    }

    public void DepartCard(NetworkObject card)
    {
        if (CardsInHand.Contains(card))
        {
                Pos3.localPosition = (Pos3.localPosition + new Vector3(0.01f, 0, 0));
                CardsInHand.Remove(card);
                ReorderCards();
  
        }
    }

    private void ReorderCards()
    {
        if (CardsInHand.Count > 0)
        {

            foreach (var item in CardsInHand){
                //CardsInHand.IndexOf(item)
                
                item.transform.localPosition = (Pos3.localPosition + new Vector3(CardsInHand.IndexOf(item) * 0.02f, 0, CardsInHand.IndexOf(item) * -0.001f) );
                item.transform.rotation = Pos3.rotation;
                Debug.Log(CardsInHand.Count);
                sfx.Play();
            }
            //CardsInHand[0].transform.position = Pos1.position;
            //CardsInHand[0].transform.rotation = Pos1.rotation;
        }
        /*if (CardsInHand.Count > 1)
        {
            CardsInHand[1].transform.position = Pos2.position;
            CardsInHand[1].transform.rotation = Pos2.rotation;
        }
        if (CardsInHand.Count > 2)
        {
            CardsInHand[2].transform.position = Pos3.position;
            CardsInHand[2].transform.rotation = Pos3.rotation;
        }
        if (CardsInHand.Count > 3)
        {
            CardsInHand[3].transform.position = Pos4.position;
            CardsInHand[3].transform.rotation = Pos4.rotation;
        }
        if (CardsInHand.Count > 4)
        {
            CardsInHand[4].transform.position = Pos5.position;
            CardsInHand[4].transform.rotation = Pos5.rotation;
        }*/

    }

    public void ResetHand()
    {
        CardsInHand = new List<NetworkObject> { };
        Pos3.localPosition = startingPos;
    }
}
