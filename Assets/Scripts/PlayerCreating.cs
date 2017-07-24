using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreating : MonoBehaviour {
    

	void Start () {
        PhotonNetwork.Instantiate("Robot Kyle", Vector3.zero, Quaternion.identity, 0);
	}
}
