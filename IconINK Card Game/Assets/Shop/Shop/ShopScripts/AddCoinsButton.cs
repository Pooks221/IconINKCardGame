using UnityEngine;
using UnityEngine.UI;

public class AddCoinsButtonScript : MonoBehaviour
{
    public Button addCoinsButton; 
    public GameObject coinSystemManager; 

    void Start()
    {
        addCoinsButton.onClick.AddListener(AddCoins);
    }

    void AddCoins()
    {
        CoinManager coinManager = coinSystemManager.GetComponent<CoinManager>();
        if (coinManager != null)
        {
            coinManager.AddCoins(100);
        }
    }
}