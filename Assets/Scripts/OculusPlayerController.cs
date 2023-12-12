using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class OculusPlayerController : MonoBehaviour
{
    public Transform VRPlayer;

    public float lookDoownAngle = 25.0f;

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
        scoringSystem = new ScoringSystem();
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
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
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
        if (other.gameObject.tag == "SpawnTrigger")
        {
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
