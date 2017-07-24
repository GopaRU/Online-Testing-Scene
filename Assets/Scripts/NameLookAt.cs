using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameLookAt: MonoBehaviour {

    Transform NeededCamera;

    void Start()
    {
        NeededCamera = GameObject.FindWithTag("Player").transform;
    }

	void Update ()
    {
           transform.LookAt(NeededCamera.transform);
	}
}
