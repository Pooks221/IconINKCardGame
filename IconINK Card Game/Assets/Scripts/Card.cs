using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.Events;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;

public class Card : NetworkBehaviour
{

    private Rigidbody rb;
    private BoxCollider boxCollider;
    public Renderer backMaterial;
    public  Renderer frontMaterial;
    public float gravity = -5;
    public float throwMultiplier = 1;
    public float maxThrowMagnitude = 10;
    public GameObject cardBack;
    public GameObject cardFace;
    public HandGrabInteractable handGrab;
    public Grabbable grabbable;
    //public UnityEvent<GameObject> toHand;
    [Networked]
    public string Suit { get; set;} = "None";
    [Networked]
    public string Value { get; set;} = "0";
    public ChangeDetector _changes { get; private set; }

    private bool gravityActive = true;
    private Vector3 lastPos = Vector3.zero;
    private bool released = false;
    private bool inLocation;
    private Vector3 handLocation;
    private Quaternion handRotation;
    private GameObject ObjectToSend;
    private bool inHand = false;
    private bool hoverPosition = false;
    private string Hand = "";
    private AudioSource sfx;

    Renderer rend;

    private const int DELTATIME_MODIFIER = 1000;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        //backMaterial = transform.Find("PlayingCard").Find("CardBack").GetComponent<Renderer>();
        //frontMaterial = transform.Find("PlayingCard").Find("CardFace").GetComponent<Renderer>();
        rb = gameObject.GetComponent<Rigidbody>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        lastPos = transform.position;


    }

    public void Awake()
    {
        setTexture();
    }

    // Update is called once per frame
    void Update()
    {
        customGravity();

        if (released)
        {
            released = false;
            Vector3 throwVector = (transform.position - lastPos) * throwMultiplier * (Time.deltaTime * DELTATIME_MODIFIER);
            Vector3.ClampMagnitude(throwVector, maxThrowMagnitude);
            rb.AddForce(throwVector);
        }
        lastPos = transform.position;
    }

    private async void setTexture()
    {
        await Task.Delay(1000);
        setSuitAndValue(Suit, Value);
    }


    private void customGravity()
    {
        if (gravityActive)
        {
            rb.AddForce(0, gravity * Time.deltaTime, 0);
        }
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void RPC_hideInCardPile(NetworkObject pile)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gravityActive = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameObject.transform.position = pile.transform.position + new Vector3(0, 0.01f, 0);
        gameObject.transform.rotation = pile.transform.rotation;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        cardBack.GetComponent<Renderer>().enabled = false;
        cardFace.GetComponent<Renderer>().enabled = false;
        grabbable.enabled = false;
        handGrab.enabled = false;
        transform.parent = pile.transform;
    }
    [Rpc(RpcSources.All, RpcTargets.All)]
    public void RPC_showCardOnPile(NetworkObject pile)
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gravityActive = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        cardBack.GetComponent<Renderer>().enabled = true;
        cardFace.GetComponent<Renderer>().enabled = true;
        grabbable.enabled = true;
        handGrab.enabled = true;
        transform.position = pile.transform.position+new Vector3(0,0.01f,0);
        transform.rotation = pile.transform.rotation;
    }

    public void onGrab()
    {
        gravityActive = false;
        transform.parent = null;
        //RPC_test();

        //if we want the card to be able to push other cards while a player is holding it, the boxcollider should not be turned off.
        //boxCollider.enabled = false;
    }
    [Rpc(RpcSources.All, RpcTargets.All)]
    private void RPC_test()
    {
        setCardToJoker();
    }

    public async void onRelease()
    {
        released = true;
        if (!inLocation)
        {
            rb.isKinematic = false;
            gravityActive = true;
            boxCollider.enabled = true;
            inHand = false;
            HandManager handM = GameObject.Find(Hand).GetComponent<HandManager>();
            handM.DepartCard(gameObject.GetComponent<NetworkObject>());
        }
        else
        {
            gravityActive = false;
            await Task.Delay(10);
            rb.isKinematic = true;
            await Task.Delay(50);
            //transform.position = (handLocation + new Vector3(0f,0.1f,0f));
            //transform.rotation = (handRotation);
            await Task.Delay(50);
            rend.enabled = false;
            inHand = true;
            HandManager handM = GameObject.Find(Hand).GetComponent<HandManager>();
            transform.parent = handM.transform;
            transform.localPosition = Vector3.zero;
            handM.RecieveCard(gameObject.GetComponent<NetworkObject>());
        }
        
    }

    public void setSuit(string s)
    {
        Suit = s;
    }

    public void setValue(string v)
    {
        Value = v;
    }
    //[Rpc(RpcSources.All, RpcTargets.All)]
    public void setSuitAndValue(string s, string v)
    {
        Suit = s;
        Value = v;

        //Debug.Log("Card Spawned:" + Value + " of " + Suit);

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

    //For testing purposes, call this to turn the card into a Joker texture
    private void setCardToJoker()
    {
        string matName = "CardMaterials/Joker";
        frontMaterial.material = (Resources.Load(matName, typeof(Material)) as Material);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand1"))
        {
            rend = other.GetComponent<Renderer>();
            rend.enabled = true;
            inLocation = true;
            handLocation = other.transform.position;
            handRotation = other.transform.rotation;
            Hand = other.transform.parent.gameObject.name;
            Debug.Log("hand name: " + Hand);
            sfx = other.GetComponent<AudioSource>();
            sfx.Play();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand1"))
        {
            rend = other.GetComponent<Renderer>();
            rend.enabled = false;
            inLocation = false;
            Hand = other.transform.parent.gameObject.name;
            Debug.Log("hand name: " + Hand);
        }
    }

    public void HighlightCard()
    {
        if (inHand)
        {
            if (!hoverPosition)
            {
                transform.position = (transform.position + new Vector3(0f, 0.01f, 0f));
                hoverPosition = true;
            }
        
        }
    }

    public void UnHighlightCard()
    {
        if (inHand)
        {
            if (hoverPosition)
            {
                transform.position = (transform.position + new Vector3(0f, -0.01f, 0f));
                hoverPosition = false;
            }
            
        }
    }

}
