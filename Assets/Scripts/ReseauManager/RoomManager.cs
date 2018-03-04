﻿using UnityEngine;
using UnityEngine.UI;

public class RoomManager : Photon.PunBehaviour {
    
    static public RoomManager instance;

    public Text roomActvies;
    public Text createRoomText;
    public Text numberText;
    public Text joinRoomText;
    public string LevelToLoad = "SceneTest";
    private const int NBR_MAX_JOUEUR = 20;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("There already is a RoomManager");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }


    public void Update()
    {
  
    }

    public void CreateRoom()
    {
        string name = createRoomText.text;
        RoomOptions ro = new RoomOptions();

        string maxPlayers = numberText.text.ToString();                                                                                      
        int i = 0;
        System.Int32.TryParse(numberText.text, out i);

        Debug.Log("i = " + i);
        if(i == 0 || ! char.IsDigit(maxPlayers, 0))
        {
            i = 1;
        }
        if(i > NBR_MAX_JOUEUR)
        {
            i = 20;
        }

        ro.MaxPlayers = (byte)i;
        PhotonNetwork.JoinOrCreateRoom(name, ro, TypedLobby.Default);
    }

    public void JoinRoom()
    {
        string name = joinRoomText.text;
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 4;
        PhotonNetwork.JoinRoom(name);
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.LoadLevel(LevelToLoad);
        }
    }


    public void RefreshRoom()
    {
        roomActvies.text = "Active Rooms";
        foreach (RoomInfo game in PhotonNetwork.GetRoomList())
        {
            roomActvies.text = roomActvies.text + "\n Room name : " + game.Name + "  Player :  " + game.PlayerCount + "/" + game.MaxPlayers;
        }
    }
}
