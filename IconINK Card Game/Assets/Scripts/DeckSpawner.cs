using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using UnityEngine.UI;
using System.Threading.Tasks;

public class DeckSpawner : NetworkBehaviour
{
    public GameObject RunnerObject;
    private NetworkRunner runner;
    public GameObject prefabDeck;
    public Toggle deckToggle;
    public GameObject DiscardPile;
    private bool TEST_MODE = true;


    private List<NetworkObject> deckList = new List<NetworkObject>();
    // Start is called before the first frame update
    void Start()
    {
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //spawnCube();
       
        //Debug.Log(Fusion.NetworkRunner.GetRunnerForGameObject(gameObject).SessionInfo.PlayerCount);
    }
    
    public void connected()
    {
        runner = Fusion.NetworkRunner.GetRunnerForGameObject(gameObject);

        if (TEST_MODE)
        {
            SpawnDeck();
        }
    }

    public void ToggleDeck()
    {
        if (deckToggle.isOn)
        {
            RPC_setDeckToggle(true);
            SpawnDeck();
        }
        else
        {
            RPC_setDeckToggle(false);
            RPC_DeleteDeck(deckList[0]);
        }
    }

    //[Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void RPC_setDeckToggle(bool isOn)
    {
        deckToggle.isOn = isOn;
    }
    [Rpc(RpcSources.All, RpcTargets.All)]
    public void RPC_DeleteDeck(NetworkObject deckObj)
    {
        deckObj.GetComponent<Deck>().DestroyDeck();
        deckList.Remove(deckObj);
    }
    public void resetDeck()
    {
        deckList[0].GetComponent<Deck>().ResetDeck();
    }
    public void shuffleDeck()
    {
        deckList[0].GetComponent<Deck>().ShuffleDeck(new List<NetworkObject>(DiscardPile.GetComponent<CardPile>().getCardList()));
        DiscardPile.GetComponent<CardPile>().setCardPile(new List<NetworkObject>());
    }

    private async void SpawnDeck()
    {
        deckList.Add(runner.Spawn(prefabDeck, transform.position, transform.rotation));
        await Task.Delay(1000);
        deckList[deckList.Count-1].GetComponent<Deck>().SpawnDeck();
    }

    //public void PickOne()
    //{
    //    SpawnDeck(1, 1);
    //}
}
