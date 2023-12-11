using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class characterMovementHelper : MonoBehaviour
{
    public SpawnManager spawnManager;
    private XROrigin x_XROrigin;
    private CharacterController x_CharacterController;
    private CharacterControllerDriver driver;
    public float speed =10f;

    [SerializeField]
    GameObject GameOverUI;
    bool isCollied= false;

    private CharacterController characterController;

    private ScoringSystem scoringSystem;
    // Start is called before the first frame update
    void Start()
    {
        x_XROrigin= GetComponent<XROrigin>();
        driver = GetComponent<CharacterControllerDriver>();
        x_CharacterController = GetComponent<CharacterController>();
        scoringSystem = new ScoringSystem();
        characterController = GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToMove = speed * Time.deltaTime;

        // Move the object in the X direction
        //transform.Translate(Vector3.forward * distanceToMove);

        Vector3 forward = x_XROrigin.transform.TransformDirection(Vector3.forward);
        characterController.SimpleMove(forward * speed);

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

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hello");
        if(other.gameObject.tag == "Box" && isCollied ==false)
        {
            GameOver();
            isCollied = true;
        }
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            scoringSystem.AddScore(1);
            Debug.Log("Coin");
        }
        if (other.gameObject.tag == "SpawnTrigger") {
            spawnManager.spawnTriggerEntered();
        }
            

    }

    private void OnTriggerExit(Collider other)
    {
        isCollied = false;
    }

    private void GameOver()
    {
        speed = 0f;
        GameOverUI.SetActive(true);
    }
    public void ResetGame(string name)
    {
        scoringSystem.Reset();
        SceneManager.LoadScene(name);
    }
}
