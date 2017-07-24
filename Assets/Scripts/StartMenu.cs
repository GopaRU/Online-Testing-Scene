using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartMenu : MonoBehaviour {

    public GameObject Message;
    public Text InMessage;
    public TypedLobby AnLobby;
    public Text RoomName;
    public GameObject RoomingMenu;
    public Text NameField;

    void Start () {
        PhotonNetwork.ConnectUsingSettings("TOOWG_0.1");
    }
	
	void Update () {
    }

    public void Connect()
    {
        Debug.Log(RoomName.text);
        RoomOptions RoomOpts = new RoomOptions();
        RoomOpts.MaxPlayers = 4;
        if (RoomName.text != "")
        {
            PhotonNetwork.JoinOrCreateRoom(RoomName.text, RoomOpts, TypedLobby.Default);
        } else
        {
            ShowMessage("Введи название комнаты");
        }
    }

    public void OnPhotonJoinRoomFailed()
    {
        ShowMessage("Комната полна");
    }

    void OnJoinedRoom()
    {
        RoomingMenu.SetActive(true);
        RoomingMenu.GetComponent<RoomMenu>().ComeToRoom();
        gameObject.SetActive(false);
    }

    public void SkipMessage()
    {
        Message.GetComponent<Animator>().SetBool("NeedToShow", false);
    }

    public void ShowMessage(string Intext)
    {
        InMessage.text = Intext;
        Message.GetComponent<Animator>().SetBool("NeedToShow", true);
    }

    public void SetMyName()
    {
        PhotonNetwork.player.NickName = NameField.text;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
