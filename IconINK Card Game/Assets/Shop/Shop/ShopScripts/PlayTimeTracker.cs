using UnityEngine;
using TMPro;

public class PlaytimeTracker : MonoBehaviour
{
    public TextMeshProUGUI CurrentTimeText;

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float sessionTime = Time.time - startTime;

        int minutes = Mathf.FloorToInt(sessionTime / 60f);
        int seconds = Mathf.FloorToInt(sessionTime % 60f);
        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (CurrentTimeText != null)
        {
            CurrentTimeText.text = "Playtime: " + formattedTime;
        }
    }
}