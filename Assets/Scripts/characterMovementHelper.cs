using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class characterMovementHelper : MonoBehaviour
{
    private XROrigin x_XROrigin;
    private CharacterController x_CharacterController;
    private CharacterControllerDriver driver;
    public float speed =10f;
    // Start is called before the first frame update
    void Start()
    {
        x_XROrigin= GetComponent<XROrigin>();
        driver = GetComponent<CharacterControllerDriver>();
        x_CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToMove = speed * Time.deltaTime;

        // Move the object in the X direction
        transform.Translate(Vector3.forward * distanceToMove);

        UpdateCharacterController();
    }

    /// <summary>
    /// Updates the <see cref="CharacterController.height"/> and <see cref="CharacterController.center"/>
    /// based on the camera's position.
    /// </summary>
    protected virtual void UpdateCharacterController()
    {
        if (x_XROrigin == null || x_CharacterController == null)
            return;

        var height = Mathf.Clamp(x_XROrigin.CameraInOriginSpaceHeight, driver.minHeight , driver.maxHeight);

        Vector3 center = x_XROrigin.CameraInOriginSpacePos;
        center.y = height / 2f + x_CharacterController.skinWidth;

        x_CharacterController.height = height;
        x_CharacterController.center = center;
    }
}
