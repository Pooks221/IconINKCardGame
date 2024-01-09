using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public GameObject playerRig;
    public GameObject seat1object;
    public GameObject seat2object;
    public GameObject seat3object;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void seat1()
    {
        playerRig.transform.position = seat1object.transform.position;
        playerRig.transform.rotation = seat1object.transform.rotation;
    }
    public void seat2()
    {
        playerRig.transform.position = seat2object.transform.position;
        playerRig.transform.rotation = seat2object.transform.rotation;
    }
    public void seat3()
    {
        playerRig.transform.position = seat3object.transform.position;
        playerRig.transform.rotation = seat3object.transform.rotation;
    }
}
