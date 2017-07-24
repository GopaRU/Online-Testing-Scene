using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RoomMenu : MonoBehaviour {

    public GameObject StartingMenu;
    public GameObject TeamatesWindow;
    public Button StartButton;
    public GameObject[] PlayersFields = new GameObject[4];
    public PhotonPlayer[] PlayerIDs = new PhotonPlayer[4];
    int MyPlayerID;
    int CountOfPlayers;



	void Start () {
    }

    public void ComeToRoom()
    {
        PhotonNetwork.automaticallySyncScene = true;
        CountOfPlayers = PhotonNetwork.playerList.Length;
        ChangeStackID();
        SwitchNames();
        if (PhotonNetwork.isMasterClient)
        {
            StartButton.interactable = true;
        }
    }

    void OnLeftRoom()
    {
        StartButton.interactable = false;
        StartingMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    void ChangeStackID()
    {
        for (int i = 0; i < CountOfPlayers; i++)
        {
            PlayerIDs[i] = PhotonNetwork.playerList[i];
        }
        for (int i = 0; i < CountOfPlayers - 1; i++)
        {
            for (int j = i + 1; j < CountOfPlayers; j++)
            {
                if (PlayerIDs[i].ID > PlayerIDs[j].ID)
                {
                    PhotonPlayer BuffPlay = PlayerIDs[i];
                    PlayerIDs[i] = PlayerIDs[j];
                    PlayerIDs[j] = BuffPlay;
                }
            }
        }
    }

    void OnPhotonPlayerConnected()
    {
        CountOfPlayers = PhotonNetwork.playerList.Length;
        ChangeStackID();
        SwitchNames();
    }

    void OnPhotonPlayerDisconnected()
    {
        if (PhotonNetwork.isMasterClient)
        {
            StartButton.interactable = true;
        }
        CountOfPlayers = PhotonNetwork.playerList.Length;
        ChangeStackID();
        SwitchNames();
    }

    void SwitchNames()
    {
        for (int i = 0; i < 4; i++ )
        {
            if (i < CountOfPlayers)
            {
                if (PlayerIDs[i] == PhotonNetwork.player)
                {
                    MyPlayerID = i;
                }
                PlayersFields[i].SetActive(true);
                Debug.Log(i + " " + (CountOfPlayers) + " " + PlayerIDs[i]);
                if (PlayerIDs[i].NickName == "")
                {
                    PlayersFields[i].GetComponentInChildren<Text>().text = "";
                    PlayersFields[i].GetComponentInChildren<InputField>().text = "Player " + (i + 1);
                } else
                {
                    PlayersFields[i].GetComponentInChildren<Text>().text = "";
                    PlayersFields[i].GetComponentInChildren<InputField>().text = PlayerIDs[i].NickName;
                }
                if (PlayerIDs[i] == PhotonNetwork.player)
                {
                    PlayersFields[i].GetComponentInChildren<InputField>().interactable = true;
                } else
                {
                    PlayersFields[i].GetComponentInChildren<InputField>().interactable = false;
                }
            } else
            {
                PlayersFields[i].SetActive(false);
            }
        }
    }

    public void ApplyName()
    {
        PlayerIDs[MyPlayerID].NickName = PlayersFields[MyPlayerID].GetComponentInChildren<InputField>().text;
        PhotonView.Get(this).RPC("ChangeMe", PhotonTargets.Others, MyPlayerID);
    }

    [PunRPC]
    public void ChangeMe(int AnID)
    {
        PlayersFields[AnID].GetComponentInChildren<InputField>().text = PlayerIDs[AnID].NickName;
    }

    public void StartMap()
    {
        SceneManager.LoadScene(1);
    }

    public void ToStartMenu()
    {
        PhotonNetwork.LeaveRoom();
    }
}
