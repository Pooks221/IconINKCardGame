using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public GameObject lobbyText;
    // Start is called before the first frame update
    void Start()
    {
        lobbyText.SetActive(false);
    }

    public void CreateRoom(int n)
    {
        lobbyText.SetActive(true);
        var str = "Room " + n;
        PhotonNetwork.CreateRoom(str);
        
        lobbyText.GetComponent<TextMeshProUGUI>().text = "You have created " + str;
    }

    public void JoinRoom(int n)
    {
        var str = "Room" + n;
        PhotonNetwork.JoinRoom(str);

        lobbyText.GetComponent<TextMeshProUGUI>().text = "You have joined " + str;
    }

    public override void OnJoinedRoom()
    {
        lobbyText.GetComponent<TextMeshProUGUI>().text += "\n PlayerCount:" + PhotonNetwork.CountOfPlayers;
    }

    //private void setLobbyName(string s)
    //{
    //    var tempString = "You have joined " + s;
    //    lobbyText.GetComponent<Text>().text = tempString;
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
