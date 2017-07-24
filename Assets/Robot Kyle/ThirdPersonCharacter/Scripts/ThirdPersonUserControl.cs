using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        private bool MyView;
        private Quaternion PreviousRotation;
        private Vector3 PreviousPosition;



        private void Start()
        {
            MyView = PhotonView.Get(this).isMine;
            if (MyView)
            {
                Camera.main.GetComponent<AudioListener>().enabled = false;
            }
            else
            {
                GetComponentInChildren<Camera>().enabled = false;
                GetComponentInChildren<AudioListener>().enabled = false;
                transform.GetComponentInChildren<TextMesh>().text = PhotonView.Get(this).owner.NickName;
            }
                //PhotonView.Get(this).RPC("SwitchMyName", PhotonTargets.AllBuffered, PhotonNetwork.player.NickName);
                // get the transform of the main camera
                // m_Cam = GameObject.FindWithTag("Player").transform;
                m_Cam = GetComponentInChildren<Camera>().transform;
            
            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
        }


        private void Update()
        {
            if (MyView)
            {
                if (!m_Jump)
                {
                    m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
                }
            }
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            if (MyView)
            {
                // read inputs
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                float v = CrossPlatformInputManager.GetAxis("Vertical");
                if (v < 0)
                {
                    v = 0;
                }
                bool crouch = Input.GetKey(KeyCode.C);

                // calculate move direction to pass to character
                if (m_Cam != null)
                {
                    // calculate camera relative direction to move:
                    m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                    m_Move = (v * m_CamForward + h * m_Cam.right) * 0.5f;
                }
                else
                {
                    // we use world-relative directions in the case of no main camera
                    m_Move = (v * Vector3.forward + h * Vector3.right) * 0.5f;
                }
#if !MOBILE_INPUT
                // walk speed multiplier
                if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 2f;
#endif

                // pass all parameters to the character control script
                m_Character.Move(m_Move, crouch, m_Jump);
                m_Jump = false;
            }
        }
    }
}
