using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardToHand : MonoBehaviour
{

    public GameObject Hand1;
    public GameObject HandCard;
    public GameObject indicator;
    public TextMeshProUGUI TSText;


    private bool inLocation;
    private Vector3 HandLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    

    public void cardToHand()
    {
        if (inLocation)
        {
            HandCard = this.gameObject;
            //HandCard.transform.SetParent(HandCard.transform);
            //HandCard.transform.localScale = Vector3.one;
            HandLocation = Hand1.transform.position;
            HandCard.transform.position.Set(0, 1, 1);
            //HandCard.transform.eulerAngles = new Vector3(25, 0, 0);

        }

    }
}
