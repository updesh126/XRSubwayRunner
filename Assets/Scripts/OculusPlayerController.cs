using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class OculusPlayerController : MonoBehaviour
{
    public Transform VRPlayer;

    public float lookDoownAngle = 15.0f;

    public float speed = 3.0f;

    public bool isPlaying = false;
    CharacterController characterController;

    [SerializeField]
    GameObject GameOverUI;
    bool isCollied = false;

    public SpawnManager spawnManager;
    private ScoringSystem scoringSystem;

    private void Start()
    {
        speed = 0f;
        scoringSystem = new ScoringSystem();
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if(VRPlayer.eulerAngles.x < lookDoownAngle && VRPlayer.eulerAngles.x < 120.0f) {
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
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Collid");
            spawnManager.spawnTriggerEntered();
        }
        if (other.gameObject.tag == "Box" && isCollied == false)
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
        //if (other.gameObject.tag == "SpawnTrigger")
        


    }

    public void StartPlayer(float PlayerSpeed)
    {
        speed = PlayerSpeed;
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
