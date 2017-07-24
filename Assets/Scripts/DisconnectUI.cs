using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DisconnectUI : MonoBehaviour {

    bool UIenable = false;
    public GameObject DiscButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIenable = !UIenable;
            if (UIenable)
            {
                DiscButton.SetActive(true);
                Cursor.visible = true;
            } else
            {
                DiscButton.SetActive(false);
                Cursor.visible = false;
            }
        }
    }

	public void DisconnectMe()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(0);
    }
}
