using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonDebug : MonoBehaviour {

    public bool PhotonDebugMode;
    
    void Start()
    {
        transform.GetComponent<PhotonDebug>().enabled = PhotonDebugMode;
    }

    void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
    }

    void OnConnectedToPhoton()
    {
        Debug.Log("OnConnectedToPhoton");
    }

    void OnConnectionFail()
    {
        Debug.Log("OnConnectionFail");
    }

    void OnCreatedRoom()
    {
        Debug.Log("OnCreatedRoom");
    }

    void OnCustomAuthenticationFailed()
    {
        Debug.Log("OnCustomAuthenticationFailed");
    }

    void OnCustomAuthenticationResponse()
    {
        Debug.Log("OnCustomAuthenticationResponse");
    }

    void OnDisconnectedFromPhoton()
    {
        Debug.Log("OnDisconnectedFromPhoton");
    }

    void OnFailedToConnectToPhoton()
    {
        Debug.Log("OnFailedToConnectToPhoton");
    }

    void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
    }

    void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
    }

    void OnLeftLobby()
    {
        Debug.Log("OnLeftLobby");
    }

    void OnLeftRoom()
    {
        Debug.Log("OnLeftRoom");
    }

    void OnLobbyStatisticsUpdate()
    {
        Debug.Log("OnLobbyStatisticsUpdate");
    }

    void OnMasterClientSwitched()
    {
        Debug.Log("OnMasterClientSwitched");
    }

    void OnOwnershipRequest()
    {
        Debug.Log("OnOwnershipRequest");
    }

    void OnOwnershipTransfered()
    {
        Debug.Log("OnOwnershipTransfered");
    }

    void OnPhotonCreateRoomFailed()
    {
        Debug.Log("OnPhotonCreateRoomFailed");
    }

    void OnPhotonCustomRoomPropertiesChanged()
    {
        Debug.Log("OnPhotonCustomRoomPropertiesChanged");
    }

    void OnPhotonInstantiate()
    {
        Debug.Log("OnPhotonInstantiate");
    }

    void OnPhotonJoinRoomFailed()
    {
        Debug.Log("OnPhotonJoinRoomFailed");
    }

    void OnPhotonMaxCccuReached()
    {
        Debug.Log("OnPhotonMaxCccuReached");
    }

    void OnPhotonPlayerActivityChanged()
    {
        Debug.Log("OnPhotonPlayerActivityChanged");
    }

    void OnPhotonPlayerConnected()
    {
        Debug.Log("OnPhotonPlayerConnected");
    }

    void OnPhotonPlayerDisconnected()
    {
        Debug.Log("OnPhotonPlayerDisconnected");
    }

    void OnPhotonPlayerPropertiesChanged()
    {
        Debug.Log("OnPhotonPlayerPropertiesChanged");
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed");
    }

    void OnPhotonSerializeView()
    {
        Debug.Log("OnPhotonSerializeView");
    }

    void OnReceivedRoomListUpdate()
    {
        Debug.Log("OnReceivedRoomListUpdate");
    }

    void OnUpdatedFriendList()
    {
        Debug.Log("OnUpdatedFriendList");
    }

    void OnWebRpcResponse()
    {
        Debug.Log("OnWebRpcResponse");
    }
}
