using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSerializing : Photon.MonoBehaviour {

    Vector3 PreviousPosition;
    Quaternion PreviousRotation;
    Vector3 CurrentPosition;
    

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            PreviousPosition = transform.position;
            PreviousRotation = transform.rotation;
            CurrentPosition = (Vector3)stream.ReceiveNext();
            transform.position = Vector3.LerpUnclamped(CurrentPosition, CurrentPosition + (CurrentPosition - PreviousPosition), 0.01f);
           // transform.position = Vector3.Lerp(CurrentPosition, PreviousPosition, 0.02f);
            transform.rotation = Quaternion.Lerp((Quaternion)stream.ReceiveNext(), PreviousRotation, 0.01f);
        }
    }
}
