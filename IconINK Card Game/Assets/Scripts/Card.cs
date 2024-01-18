using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    private Rigidbody rb;
    private BoxCollider boxCollider;

    private string suit = "None";
    private string value= "0";
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
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
}
