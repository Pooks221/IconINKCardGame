using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Photon.Pun;
using Fusion;
using UnityEngine.UI;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviour
{
    public GameObject lobbyText;
    public GameObject PlayerCountText;
    public TMP_InputField inputTextField;
    public NetworkRunner runner;

    private TextMeshProUGUI textMesh;
    private TextMeshProUGUI playerCountTextMesh;
    private List<SessionInfo> sessionList;

    private bool TEST_MODE = false;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        lobbyText.SetActive(false);
        textMesh = lobbyText.GetComponent<TextMeshProUGUI>();
        playerCountTextMesh = PlayerCountText.GetComponent<TextMeshProUGUI>();
        if (TEST_MODE)
        {
            CreateRoom("AutoCreateRoom");
        }
    }

    public void CreateRoom(string str)
    {
        lobbyText.SetActive(true);
        //PhotonNetwork.CreateRoom(str);
        runner.StartGame(new StartGameArgs()
        {
            GameMode = GameMode.Shared,
            SessionName = str
        });

        textMesh.text = "Creating: " + str;
    }
    public void SubmitRoom()
    {
        string roomStr = inputTextField.text;
        JoinRoom(roomStr);
        textMesh.text = "Loading Room: " + roomStr;
        //runner.JoinSessionLobby(SessionLobby.Shared);

        //bool foundRoom = false;
        //string roomStr = inputTextField.text;
        //for(int i = 0; i < sessionList.Count; i++)
        //{
        //    if (sessionList[i].Name.Equals(roomStr))
        //        foundRoom = true;
        //}
        //if (foundRoom)
        //{
        //    JoinRoom(roomStr);
        //}
        //else
        //{
        //    CreateRoom(roomStr);
        //}

    }

    public void JoinRoom(string str)
    {
        lobbyText.SetActive(true);
        runner.StartGame(new StartGameArgs()
        {
            GameMode = GameMode.Shared,
            SessionName = str
        });

        textMesh.text = "Joining: " + str;
    }
    public void LeaveRoom()
    {
        lobbyText.SetActive(true);
        //runner.leave

        textMesh.text = "Leaving Room...";
    }

    public void OnLeftRoom()
    {
        textMesh.text = "Room Left!";
    }

    public void OnJoinedRoom()
    {
        textMesh.text = "Sucessfully joined room: " + runner.SessionInfo.Name;
    }
    public void OnCreatedRoom()
    {
        textMesh.text = "Sucessfully created room: " + runner.SessionInfo.Name;
    }

    public void SetSessionList(NetworkRunner runner, List<SessionInfo> sList)
    {
        sessionList = sList;
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
            playerCountTextMesh.text = "Player Count: "+ runner.SessionInfo.PlayerCount;
        }
    }
}
