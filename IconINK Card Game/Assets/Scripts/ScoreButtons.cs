using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreButtons : MonoBehaviour
{

    public TextMeshPro numberText;
    int score;

    public void IncreasePressed()
    {
        score++;
        numberText.text = "Score\n" + score;
    }

    public void DecreasePressed()
    {
        score--;
        numberText.text = "Score\n" + score;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
