using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    public TMP_Text timeText;

    void Update()
    {
        System.DateTime currentTime = System.DateTime.Now;
        string timeString = currentTime.ToString("hh:mm tt");
        timeText.text = timeString;
    }
}
