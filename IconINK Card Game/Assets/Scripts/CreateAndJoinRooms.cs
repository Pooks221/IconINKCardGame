using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public GameObject lobbyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CreateRoom(int n)
    {
        var str = "Room" + n;
        PhotonNetwork.CreateRoom(str);
        
        lobbyText.GetComponent<Text>().text = "You have created " + str;
    }

    public void JoinRoom(int n)
    {
        var str = "Room" + n;
        PhotonNetwork.JoinRoom(str);

        lobbyText.GetComponent<Text>().text = "You have joined " + str;
    }

    public override void OnJoinedRoom()
    {
        lobbyText.GetComponent<Text>().text += "\n PlayerCount:" + PhotonNetwork.CountOfPlayers;
    }
    public override void OnCreatedRoom()
    {
        lobbyText.GetComponent<Text>().text += "\n PlayerCount:" + PhotonNetwork.CountOfPlayers;
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
