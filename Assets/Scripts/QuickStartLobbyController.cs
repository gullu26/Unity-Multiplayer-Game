﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject quickStartButton;
    [SerializeField]
    private GameObject quickCancelButton;
    [SerializeField]
    private int RoomSize;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        quickStartButton.SetActive(true);
    }

    public void QuickStart()
    {
        quickStartButton.SetActive(false);
        quickCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("QuickStart");

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join room");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Creating room");
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)(RoomSize) };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        Debug.Log("Created Room" + randomRoomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room, trying again");
        CreateRoom();
    }

    public void QuickCancel()
    {
        quickCancelButton.SetActive(false);
        quickStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
