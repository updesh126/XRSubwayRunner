using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class OculusPlayerController : MonoBehaviour
{
    public Transform VRPlayer;

    public float lookDoownAngle = 25.0f;

    public float speed = 3.0f;

    public bool isPlaying = false;
    CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if(VRPlayer.eulerAngles.x < lookDoownAngle && VRPlayer.eulerAngles.x < 90.0f) {
            isPlaying = true;
        }
        else
        {
            isPlaying = false;
        }

        if (isPlaying == true)
        {
            Vector3 foward = VRPlayer.TransformDirection(Vector3.forward);
            characterController.SimpleMove(foward * speed);
        }
    }

}
