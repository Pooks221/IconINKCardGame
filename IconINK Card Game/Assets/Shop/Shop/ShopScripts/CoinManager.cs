using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerCoinData
{
    public int coins = 0;
}

public class CoinManager : MonoBehaviour
{
    private const string COIN_DATA_KEY = "CoinData";

    public int coins = 0;
    public float timeToEarnCoin = 60.0f;
    private float timer = 0.0f;

    void Start()
    {
        LoadCoins();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToEarnCoin)
        {
            coins++;
            timer = 0.0f;
            SaveCoins();
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        SaveCoins();
    }

    public void SaveCoins()
    {
        PlayerCoinData data = new PlayerCoinData();
        data.coins = coins;
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(COIN_DATA_KEY, jsonData);
        PlayerPrefs.Save();
    }

    public void LoadCoins()
    {
        if (PlayerPrefs.HasKey(COIN_DATA_KEY))
        {
            string jsonData = PlayerPrefs.GetString(COIN_DATA_KEY);
            PlayerCoinData data = JsonUtility.FromJson<PlayerCoinData>(jsonData);
            coins = data.coins;
        }
    }

    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            SaveCoins();
            return true; 
        }
        else
        {
            return false; 
        }
    }

    void OnApplicationQuit()
    {
        SaveCoins();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveCoins();
        }
    }
}
