using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR;
using Unity.XR.CoreUtils;

public class LaneManager : MonoBehaviour
{
    [SerializeField]
    private XROrigin xrOrigin;

    [SerializeField]
    private bool Left, Right, isActive;

    private void Start()
    {
        Left = false;
        Right = false;
        isActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        float mLeft = 2f;
        float mRight = -2f;
        float mMid = 0f;
        if(Left== false && isActive== true && other.gameObject.tag == "LeftWall")
        {
            isActive = false;
            Debug.Log("Hello Left wall");
            xrOrigin.transform.Translate(Vector3.left * mLeft);
            Left = true;
        }
        if (Right == false && isActive == true && other.gameObject.tag == "RightWall")
        {
            isActive = false;
            Debug.Log("Hello Right wall");
            xrOrigin.transform.Translate(Vector3.left * mRight);
            Right = true;
        }
        if( Left == true && isActive == true && other.gameObject.tag == "LeftWall")
        {
            isActive = false;
            Debug.Log("Hello Left to mid");
            xrOrigin.transform.Translate(Vector3.left * mRight);
            Left = false;
        }
        if (Right == true && isActive == true && other.gameObject.tag == "RightWall")
        {
            isActive = false;
            Debug.Log("Hello Right to mid ");
            xrOrigin.transform.Translate(Vector3.left * mLeft);
            Right = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isActive = true;
    }
}
