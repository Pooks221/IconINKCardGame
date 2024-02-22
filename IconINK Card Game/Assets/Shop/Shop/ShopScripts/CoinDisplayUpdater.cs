using UnityEngine;
using TMPro;

public class CoinDisplayUpdater : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public CoinManager coinManager; // Assign this in the Inspector

    void Update()
    {
        if (coinText != null && coinManager != null)
        {
            coinText.text = "Coins: " + coinManager.coins;
        }
    }
}

