using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour


    
{

    public UnityEvent<int> noPassthrough;
    // Start is called before the first frame update
    void Start()
    {
        int myValue = 0;
        noPassthrough.Invoke(myValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
