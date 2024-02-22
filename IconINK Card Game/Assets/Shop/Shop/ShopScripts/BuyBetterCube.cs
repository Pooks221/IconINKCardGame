using UnityEngine;
using UnityEngine.UI;

public class BuyBetterCubeButton : MonoBehaviour
{
    public CoinManager coinManager;
    public GameObject BetterCube;
    public int cost = 100;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(TryBuyBetterCube);
    }

    void TryBuyBetterCube()
    {

        if (coinManager.SpendCoins(cost))
        {
            BetterCube.SetActive(true);
        }
        else
        {
            Debug.Log("Not enough coins to buy the BetterCube.");
        }
    }
}