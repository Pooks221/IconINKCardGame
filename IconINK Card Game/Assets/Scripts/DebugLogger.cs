using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugLogger : MonoBehaviour
{

    Dictionary<string, string> debugLogs = new Dictionary<string, string>();
    // Start is called before the first frame update
    public TextMeshProUGUI display;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.name);
        //Debug.Log("time:" + Time.time);
    }

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Log)
        {
            string[] splitString = logString.Split(char.Parse(":"));
            string debugKey = splitString[0];
            string debugValue = splitString.Length > 1 ? splitString[1] : "";

            if (debugLogs.ContainsKey(debugKey))
            {
                debugLogs[debugKey] = debugValue;
            }
            else
            {
                debugLogs.Add(debugKey, debugValue);
            }
        }

        string displayText = "";
        foreach(KeyValuePair<string,string> log in debugLogs)
        {
            if(log.Value == "")
            {
                displayText += log.Key + "\n";
            }
            else
            {
                displayText += log.Key + ":" + log.Value+ "\n";
            }
            display.text = displayText;
        }
    }
}
