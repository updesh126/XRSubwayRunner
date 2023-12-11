using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunner : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;

    // Adjust these based on your gyro sensor readings
    private float pitchInput;

    private void Start()
    {
        // Ensure gyro is enabled
        Input.gyro.enabled = true;
    }

    private void Update()
    {
        // Read input from gyro sensor
        pitchInput = Input.gyro.attitude.eulerAngles.x;

        // Move the player forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Rotate the player based on gyro input for changing direction
        transform.Rotate(0f, pitchInput * rotationSpeed * Time.deltaTime, 0f);
    }
}
