using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayLocalTime : MonoBehaviour
{
    public TMP_Text timeText; // Assign your TextMeshPro text field in the Inspector

    void Update()
    {
        DateTime localTime = DateTime.Now; // Get current local time
        timeText.text = localTime.ToString("h:mm tt"); // Format the time (e.g., 9:25 PM) 
    }
}
