using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.Events;

public class Card : NetworkBehaviour
{

    private Rigidbody rb;
    private BoxCollider boxCollider;
    public Renderer backMaterial;
    public  Renderer frontMaterial;
    public float gravity = -5;
    public float throwMultiplier = 1;
    public float maxThrowMagnitude = 10;
    //public UnityEvent<GameObject> toHand;
    

    private string suit = "None";
    private string value= "0";
    private bool gravityActive = true;
    private Vector3 lastPos = Vector3.zero;
    private bool released = false;
    private bool inLocation;
    private Vector3 handLocation;
    private Quaternion handRotation;

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

    private void customGravity()
    {
        if (gravityActive)
        {
            rb.AddForce(0, gravity * Time.deltaTime, 0);
        }
    }

    public void onGrab()
    {
        gravityActive = false;
        //RPC_test();

        //if we want the card to be able to push other cards while a player is holding it, the boxcollider should not be turned off.
       // boxCollider.enabled = false;
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
        }
        else
        {
            gravityActive = false;
            await Task.Delay(10);
            rb.isKinematic = true;
            await Task.Delay(50);
            transform.position = (handLocation + new Vector3(0f,0.1f,0f));
            transform.rotation = (handRotation);
            await Task.Delay(50);
            rend.enabled = false;
        }
        
    }

    public void setSuit(string s)
    {
        suit = s;
    }

    public void setValue(string v)
    {
        value = v;
    }
    //[Rpc(RpcSources.All, RpcTargets.All)]
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
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand1"))
        {
            rend = other.GetComponent<Renderer>();
            rend.enabled = false;
            inLocation = false;
        }
    }


}
