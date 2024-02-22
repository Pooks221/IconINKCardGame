using UnityEngine;
using UnityEngine.UI;
using System;

public class DailyCoinsButtons : MonoBehaviour
{
    public Button dailyCoinsButton; 
    public GameObject coinSystemManager;

    private const string LAST_USED_KEY = "LastUsed";

    void Start()
    {
        dailyCoinsButton.onClick.AddListener(AddDailyCoins);

        
        string lastUsed = PlayerPrefs.GetString(LAST_USED_KEY, string.Empty);
        if (!string.IsNullOrEmpty(lastUsed))
        {
            DateTime lastUsedDate = DateTime.Parse(lastUsed);
            if (lastUsedDate.Date == DateTime.Today)
            {
                dailyCoinsButton.interactable = false;
            }
        }
        void AddDailyCoins()
        {
            CoinManager coinManager = coinSystemManager.GetComponent<CoinManager>();
            if (coinManager != null)
            {
                coinManager.AddCoins(100);
                dailyCoinsButton.interactable = false;
                PlayerPrefs.SetString(LAST_USED_KEY, DateTime.Now.ToString());
                PlayerPrefs.Save();
            }
        }
    }
 
}