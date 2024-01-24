using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Card : NetworkBehaviour
{

    private Rigidbody rb;
    private BoxCollider boxCollider;
    public Renderer backMaterial;
    public  Renderer frontMaterial;

    private string suit = "None";
    private string value= "0";
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        //backMaterial = transform.Find("PlayingCard").Find("CardBack").GetComponent<Renderer>();
        //frontMaterial = transform.Find("PlayingCard").Find("CardFace").GetComponent<Renderer>();
        gameObject.GetComponent<Rigidbody>();
        gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onGrab()
    {
        rb.useGravity = false;
        //boxCollider.
    }

    public void onRelease()
    {
        rb.useGravity = true;
    }

    public void setSuit(string s)
    {
        suit = s;
    }

    public void setValue(string v)
    {
        value = v;
    }
    [Rpc(RpcSources.All, RpcTargets.All)]
    public void RPC_setSuitAndValue(string s, string v)
    {
        suit = s;
        value = v;

        Debug.Log("Card Spawned:" + value + " of " + suit);

        string matName = "CardMaterials/";
        switch (s)
        {
            case "Heart":
                matName += "H";
            break;
            case "Diamond":
                matName += "D";
                break;
            case "Spade":
                matName += "S";
                break;
            case "Club":
                matName += "C";
                break;
            case "Joker":
                matName += "Joker";
                break;
        }
        switch (v)
        {
            case "Ace":
                matName += "01";
                break;
            case "10":
                matName += "10";
                break;
            case "Jack":
                matName += "11";
                break;
            case "Queen":
                matName += "12";
                break;
            case "King":
                matName += "13";
                break;
            case "Joker":
                break;
            default:
                matName += "0" + v + "";
                break;

        }
        frontMaterial.material = (Resources.Load(matName, typeof(Material)) as Material);
    }
}
