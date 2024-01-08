using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public GameObject lobbyText;
    public GameObject PlayerCountText;

    private TextMeshProUGUI textMesh;
    private TextMeshProUGUI playerCountTextMesh;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        lobbyText.SetActive(false);
        textMesh = lobbyText.GetComponent<TextMeshProUGUI>();
        playerCountTextMesh = PlayerCountText.GetComponent<TextMeshProUGUI>();
    }

    public void CreateRoom(int n)
    {
        lobbyText.SetActive(true);
        var str = "Room"+n;
        PhotonNetwork.CreateRoom(str);

        textMesh.text = "Creating: " + str;
    }
    public override void OnJoinedLobby()
    {
        textMesh.text = "Joined Lobby: "+PhotonNetwork.CurrentLobby;

      
    }

    public void JoinRoom(int n)
    {
        var str = "Room" + n;
        PhotonNetwork.JoinRoom(str);

        textMesh.text = "Joining: " + str;
    }

    public override void OnJoinedRoom()
    {
        textMesh.text = "Sucessfully joined room: " + PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        textMesh.text = message;
    }

    //private void setLobbyName(string s)
    //{
    //    var tempString = "You have joined " + s;
    //    lobbyText.GetComponent<Text>().text = tempString;
    //}

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = 1;
            playerCountTextMesh.text = "Player Count: "+ PhotonNetwork.CurrentRoom.PlayerCount;
        }
    }
}
