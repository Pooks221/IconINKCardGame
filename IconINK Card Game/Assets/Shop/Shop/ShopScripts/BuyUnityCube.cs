using UnityEngine;
using UnityEngine.UI;

public class BuyUnityCubeButton : MonoBehaviour
{
    public CoinManager coinManager; 
    public GameObject unityCube; 
    public int cost = 50;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(TryBuyUnityCube);
    }

    void TryBuyUnityCube()
    {
        
        if (coinManager.SpendCoins(cost))
        {
            unityCube.SetActive(true);
        }
        else
        {
            Debug.Log("Not enough coins to buy the UnityCube.");
        }
    }
}