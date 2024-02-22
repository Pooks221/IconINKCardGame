using UnityEngine;
using UnityEngine.UI;

public class BuyBestCubeButton : MonoBehaviour
{
    public CoinManager coinManager;
    public GameObject BestCube;
    public int cost = 1000;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(TryBuyBestCube);
    }

    void TryBuyBestCube()
    {

        if (coinManager.SpendCoins(cost))
        {
            BestCube.SetActive(true);
        }
        else
        {
            Debug.Log("Not enough coins to buy the BetterCube.");
        }
    }
}